using System;
using System.Collections.Generic;
using System.Linq;


namespace Performace_Produto
{
    class CalculationService
    {
        public T Max<T>(List<T> list) where T : IComparable //Procurar o maior número na lista
        {
            if(list.Count == 0)
            {
                throw new ArgumentException("Lista vazia");
            }

            list.Sort();
            T max = list.Last();
            
            return max;
        }
    }
}
