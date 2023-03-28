using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsoDeLinQ;

namespace TPP.Laboratory.tpplab_poo_pfunc
{
    
    class Query {

        private Modelo m = new Modelo();
        private LinQ lin = new LinQ();
       
        static void Main(string[] args) {
            Query query = new Query();
            
            try
            {
               // query.Query1();
                query.Query2();
              //  query.Query3();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: {0}", ex.StackTrace);
            }            
        }

////////----------version Currificacion-----------------------------------------
	public Func<Jugador, bool> compararEquipo(String nacionalidad)
     {
        return j => j.Nacionalidad.Equals(nacionalidad);
     }
//Correcto------------------------------------------
  private void Query1Currificacion()
         {
	      IList<Equipo> equipos = new List<Equipo>();
            var sol = m.Equipos.ReducirExtensor<Equipo, IList<Equipo>>((listae, e) =>
            {
                foreach (Jugador j in e.Jugadores)
                {
                    //if (j.Nacionalidad.Equals("ESP"))
                    if(compararEquipo("ESP")(j)) //Currificacion
                        if (!listae.Contains(e))
                            listae.Add(e);
                }
                return listae;
            },equipos);
		//mostrar lista equipos
		 }
///////////////////////////////////////////////////////////////////		
         // Ejercicio 2. 3 puntos.
         // Mostrar la lista de equipos que tengan algun jugador español ("ESP") usando linq. 
         private void Query2()
         {//any: retorna true, los que cumplen el criterio
             var equipos = m.Equipos.Select((e =>
                 new
                 {
                     Nombre=e.Name,
                     equipossol=e.Jugadores.Any(y=>y.Nacionalidad.Equals("ESP")),
   
                 })).where(e=>e.equipossol==true);
           
             Console.WriteLine("----------------------------");
             foreach (var e in equipos)
             {
                 Console.WriteLine("Equipos: "+e.Nombre);
                // Console.WriteLine(e.equipossol);
                //Console.WriteLine(e.equipo);
             }
         }
        
         // Ejercicio 3. 2 puntos
        
        // Mostrar el nombre, apellidos y puntuación del jugador con mas puntos (1p+2*2p+3*3p) en las 10 temporadas
        
        private void Query3()
         {
             var estadisticas=m.Estadisticas.Join(m.Jugadores, e => e.Dni, j => j.Dni, (x, y) =>
                 new
                 {
                     puntuacion = x.Canastas1P + x.Canastas2P * 2 + x.Canastas3P * 3,
                     dni = y.Dni,
                 }).GroupBy(x => x.jugador).Select(j =>
                 new
                 {
          
                     dni=j.Key,
                     PuntosMax=j.Sum(h=>h.puntuacion)
                 }
				 var jugadorMax=estadisticas.FirstOrDefault(e=>e.PuntosMax==estadisticas.Max(e=>e.PuntosMax));
                 );

//----------------------------------------------
          
                  

         }
       

    }
       
}
