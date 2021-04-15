using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A827535.Actividad02
{
    class Registro
    {
        public void IngresarValores()
        {
            string Ingreso;
            int NroRegistro = 0;
            int NroRanking = 0;
            int NroCurso = 0;
            int Capacidad = 0;
            int CapacidadTotal = 0;
            int CantidadAlumnos = 0;
            int CantidadCursos = 0;
            string Condicion;
            bool Flag;

            Dictionary<int, int> Alumnos = new Dictionary<int, int>()
            { };
            Dictionary<int, int> Cursos = new Dictionary<int, int>()
            { };
            Dictionary<int, int> Asignacion = new Dictionary<int, int>()
            { };

            //Ingreso de datos
            do
            {
                do
                {
                    Console.WriteLine("Ingrese Nro registro del alumno:");
                    Ingreso = Console.ReadLine();
                    Flag = ValidarNumero(Ingreso, ref NroRegistro);
                } while (Flag == false);

                do
                {
                    Console.WriteLine("Ingrese Ranking del alumno:");
                    Ingreso = Console.ReadLine();
                    Flag = ValidarNumero(Ingreso, ref NroRanking);
                } while (Flag == false);

                Alumnos.Add(NroRegistro, NroRanking);
                CantidadAlumnos += 1;

                do
                {
                    Console.WriteLine("¿Desea ingresar otro alumno? SI/NO:");
                    Condicion = Console.ReadLine();
                    Flag = ValidarVacio(Condicion, "Condicion");
                } while (Flag == false);



            } while (Condicion == "SI");


            do
            {
                do
                {
                    Console.WriteLine("Ingrese Nro del Curso:");
                    Ingreso = Console.ReadLine();
                    Flag = ValidarNumero(Ingreso, ref NroCurso);
                } while (Flag == false);

                do
                {
                    Console.WriteLine("Ingrese la capacidad del curso:");
                    Ingreso = Console.ReadLine();
                    Flag = ValidarNumero(Ingreso, ref Capacidad);
                } while (Flag == false);


                Cursos.Add(NroCurso, Capacidad);
                CantidadCursos += 1;
                CapacidadTotal += Capacidad;

                do
                {
                    Console.WriteLine("¿Desea ingresar otro curso? SI/NO:");
                    Condicion = Console.ReadLine();
                    Flag = ValidarVacio(Condicion, "Condicion");
                } while (Flag == false);



            } while (Condicion == "SI");


            //Ordenamiento por ranking del alumno
            Alumnos = Alumnos.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Cursos = Cursos.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //Visualización de los datos cargados
            Console.WriteLine("La cantidad de cursos es: " + CantidadCursos);
            Console.WriteLine("La cantidad de alumnos es: " + CantidadAlumnos);
            Console.WriteLine("La capacidad total de alumnos es: " + CapacidadTotal);


        }
        private bool ValidarNumero(string Numero, ref int Salida)
        {
            bool Flag = false;

            if (!int.TryParse(Numero, out Salida))
            {
                Console.WriteLine("Usted debe ingresar un dato númerico");
            }
            else if (Salida <= 0)
            {
                Console.WriteLine("Usted debe ingresar un numero positivo.");
            }
            else
            {
                Flag = true;
            }

            return Flag;
        }
        private bool ValidarVacio(string Valor, string CampoDependiendoDeVariable)
        {
            bool Flag = false;

            if (string.IsNullOrEmpty(Valor))
            {
                Console.WriteLine("El campo " + CampoDependiendoDeVariable + " no puede estar vacio");
            }
            else
            {
                Flag = true;
            }
            return Flag;
        }
    }

}