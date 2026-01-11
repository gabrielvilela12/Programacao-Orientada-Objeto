namespace Exemplo
{
    static class StringsExtension
    {
        public static string Cut(this string thisObj, int count) //this utilizado para se referir a variável que foi chamadada
        {
            if(thisObj.Length < count)
            {
                return thisObj;
            }
            else
            {
                return thisObj.Substring(0, count) + " || Cortado em " + count;
            }
        }
    }
}
