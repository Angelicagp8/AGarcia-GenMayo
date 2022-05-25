using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese Nombre");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoPaterno");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese ApellidoMaterno");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Sexo");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP");
            usuario.CURP = Console.ReadLine();

            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Se ha registrado la materia");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar la materia" + result.ErrorMessage);
            }
        }


    }
}
