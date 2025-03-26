namespace CarDealer
{
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json; 
    
    using Data;
    using DTOs.Import;
    using Models;
    using Newtonsoft.Json.Serialization;

    public class StartUp
    {
        public static void Main()
        {
            string jsonString = File.ReadAllText("../../../Datasets/sales.json");
            
            CarDealerContext context = new CarDealerContext();

            var result = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(result);

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<SupplierDTO[]>(inputJson);

            var validSuppliers = new List<Supplier>();

            foreach (var supplier in suppliers) {
                if (!IsValid(supplier))
                {
                    continue;
                }
                var validSupplier = new Supplier
                {
                    Name = supplier.Name,
                    IsImporter = supplier.IsImporter
                };
                validSuppliers.Add(validSupplier);
            }


            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Length}.";
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<PartDto[]>(inputJson);
            var validParts = new List<Part>();

            var supplierId = context.Suppliers.Select(s => s.Id).ToList();

            foreach (var part in parts)
            {
                if (!IsValid(part))
                {
                    continue;
                }
                
                if (!supplierId.Contains(part.SupplierId))
                {
                    continue;
                }

                var validPart = new Part
                {
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    SupplierId = part.SupplierId
                };
                validParts.Add(validPart);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}.";

        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
           var cars = JsonConvert.DeserializeObject<CarDto[]>(inputJson);
           var validCars = new List<Car>();

           var partsId = context.Parts.Select(p => p.Id).ToList();

            foreach (var car in cars)
            {
                if (!IsValid(car))
                {
                    continue;
                }

                var validCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TraveledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    if (!partsId.Contains(partId))
                    {
                        continue;
                    }
                    validCar.PartsCars.Add(new PartCar
                    {
                        PartId = partId
                    });
                }

                validCars.Add(validCar);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<CustomerDto[]>(inputJson);
            var validCustomers = new List<Customer>();

            foreach (var customer in customers)
            {
                if (!IsValid(customer))
                {
                    continue;
                }

                if (!DateTime.TryParse(customer.BirthDate, out DateTime valiDateTime))
                {
                    continue;
                }

                var validCustomer = new Customer
                {
                    Name = customer.Name,
                    BirthDate = valiDateTime,
                    IsYoungDriver = customer.IsYoungDriver
                };
                validCustomers.Add(validCustomer);
            }
            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}.";

        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<SalesDto[]>(inputJson);

            var validSales = new List<Sale>();

            var carsId = context.Cars.Select(c => c.Id).ToList();

            var customersId = context.Customers.Select(c => c.Id).ToList();

            foreach (var sale in sales)
            {
                if (!IsValid(sale) )
                {
                    continue;
                }

                var validSale = new Sale
                {
                    CarId = sale.CarId,
                    CustomerId = sale.CustomerId,
                    Discount = sale.Discount
                };
                validSales.Add(validSale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}.";
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars
                        .Select(p => new
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price.ToString("F2")
                        })
                        .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => (decimal?)pc.Part.Price) ?? 0 
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            DefaultContractResolver camelCaseResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented, new JsonSerializerSettings()
            {
                ContractResolver = camelCaseResolver
            });

            return json;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("F2"),
                    price = s.Car.PartsCars.Sum(pc => pc.Part.Price).ToString("F2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) - s.Car.PartsCars.Sum(pc => pc.Part.Price) * s.Discount / 100).ToString("F2")
                })
                .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return json;
        }

        //Help Method
        private static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResults, true);

            return isValid;
        }
    }
}