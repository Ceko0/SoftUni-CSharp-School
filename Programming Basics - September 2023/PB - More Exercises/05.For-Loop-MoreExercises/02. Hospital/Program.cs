int dayCounter = int.Parse(Console.ReadLine());
int treatedPatients = 0;
int untreatedPatients = 0;
int doctors = 7;

for (int i = 1; i <= dayCounter; i++)
{
    if (i % 3 == 0) if (treatedPatients < untreatedPatients) doctors++;

    int patientsPerDay = int.Parse(Console.ReadLine());

    if (patientsPerDay > doctors) 
    { 
        untreatedPatients += patientsPerDay - doctors; 
        treatedPatients += doctors; 
    }
    else if (patientsPerDay == doctors) treatedPatients += doctors;
    else treatedPatients += doctors - (doctors - patientsPerDay);   
}
Console.WriteLine($"Treated patients: {treatedPatients}.");
Console.WriteLine($"Untreated patients: {untreatedPatients}.");