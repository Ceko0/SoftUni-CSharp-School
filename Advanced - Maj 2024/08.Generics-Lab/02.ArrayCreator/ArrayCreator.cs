namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public static T[] Create<T>(int length, T element)
        {
            T[] elements = new T[length];
            for (int i = 0; i < length; i++)
            {
                elements[i] = element;
            }
            return elements;
        }
    }
}
