using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace model
{
    public static class MetodoExtensor
    {
      
		//Sustituir Aggregate por implementacion manual
        public static  K ReducirExtensor<T, K>(this IEnumerable<T> elementos, Func<K, T, K> f,K r = default(K)) //
        {
            K resultado =r;
            resultado = elementos.Aggregate(resultado, f);//necesitaba donde acumula el resultado y la función
            return resultado;
        }
		
	public static IEnumerable<T> Filtrar<T>(this IEnumerable<T> elementos, Func<T, bool> f)
        {
           for()
			   if(f(x))
				   lista.add(x);
            return resultado;
        }
       
    }
}
