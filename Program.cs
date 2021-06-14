using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Comentario
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public Usuario(string nombre)
        {
            Nombre = nombre;
        }
        
    }
    public class Coment
    {
        public int ID { get; set; }
        public string Autor { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public string DireccionIP { get; set; }
        public int Inapropiado { get; set; }
        public int Likes { get; set; }
      
   
        public override string ToString()
        { 
        if (Inapropiado > Likes)
            {
                return String.Format("**********Comentario borrado por tu comodidad*********");
            }
            else
            {
                return String.Format($" ID: {ID} - Autor: {Autor} - Fecha: {Fecha} - Comentario: {Comentario} - Dirección IP: {DireccionIP} - Inapropiado: {Inapropiado} - Likes: {Likes} ");
            }
        }

       
       
    }
    public class ComentarioDB 
    {
        public static void SaveToFile(List<Coment> Comentarios, string path)
        {
            StreamWriter textout = null;
            try
            {
                textout = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write));
               
                foreach (var comenta in Comentarios)
                {
                    textout.Write(comenta.ID + "|");
                    textout.Write(comenta.Autor + "|");
                    textout.Write(comenta.Fecha + "|");
                    textout.Write(comenta.Comentario + "|");
                    textout.Write(comenta.DireccionIP + "|");
                    textout.Write(comenta.Inapropiado + "|");
                    textout.WriteLine(comenta.Likes);
                    
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Ya existe ese archivo");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (textout != null)
                    textout.Close();
            }
        }

        public static void NewComent(List<Coment> Comentarios, string path)
        {
            StreamWriter textout = null;
            try
            {
                textout = new StreamWriter(new FileStream(path, FileMode.Append, FileAccess.Write));
                // Apend abre un archivo y en la parte de abajo del archivo agrega la nueva información 
                foreach (var comenta in Comentarios)
                {
                    textout.Write(comenta.ID + "|");
                    textout.Write(comenta.Autor + "|");
                    textout.Write(comenta.Fecha + "|");
                    textout.Write(comenta.Comentario + "|");
                    textout.Write(comenta.DireccionIP + "|");
                    textout.Write(comenta.Inapropiado + "|");
                    textout.WriteLine(comenta.Likes);
                }
            }
            catch (IOException )
            {
                Console.WriteLine("Ya existe ese archivo");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (textout != null)
                    textout.Close();
            }
        }

        public static List<Coment> ReadFromFile(string path)
        {
            List<Coment> Coments = new List<Coment>();
            StreamReader TextIn = null;
            try
            {
                TextIn = new StreamReader(new FileStream(path, FileMode.Open, FileAccess.Read));
                while (TextIn.Peek() != -1)
                {
                    string row = TextIn.ReadLine();
                    string[] columns = row.Split('|');
                    Coment c = new Coment();
                    c.ID = int.Parse(columns[0]);
                    c.Autor = columns[1];
                    c.Fecha = DateTime.Parse(columns[2]);
                    c.Comentario = columns[3];
                    c.DireccionIP = columns[4];
                    c.Inapropiado = int.Parse(columns[5]);
                    c.Likes = int.Parse(columns[6]);
                    Coments.Add(c);
                }
            }
            catch (IOException) { }
            catch (Exception) { }
            finally
            {
                TextIn.Close();
            }
            return Coments;
        }
        public static void GetLikes (string path)
        {
            List<Coment> Comentarios;

            try
            {
                Comentarios = ReadFromFile(path);
                var Ordnar_Likes = from c in Comentarios
                                   orderby c.Likes descending
                                   select c;
                foreach (var c in Ordnar_Likes)
                    Console.WriteLine(c);
            }
            catch (Exception)
            {
                Console.WriteLine("El archivo no es tipo .txt");
            }
           

        }

      public static void GetTime(string path)
        {
            List<Coment> coment;
            try
            {

                coment = ReadFromFile(path);
                var Ordenar_Fecha = from c in coment
                                   orderby c.Fecha descending
                                   select c;
                foreach (var c in Ordenar_Fecha)
                    Console.WriteLine(c);

            }
            catch (Exception e) 
            {
                Console.WriteLine("Error");
            }
            
            
           

        }
    }
        
   
       

    class Program
    {
        static void Main(string[] args)
        {
            /*List<Coment> comentarios = new List<Coment>();
            comentarios.Add(new Coment { ID = 1, Autor = "Carl", Fecha = new DateTime(2021, 5, 12), Comentario = "Hola, que tal weyes ", DireccionIP = "902.180.61.01", Inapropiado = 9, Likes = 2 });
            comentarios.Add(new Coment { ID = 2, Autor = "Pedro", Fecha = new DateTime(2020, 12, 12), Comentario = "Hola amigos linda tarde", DireccionIP = "982.181.66.21", Inapropiado = 0, Likes = 12 });
            comentarios.Add(new Coment { ID = 3, Autor = "Juan", Fecha = new DateTime(2020, 10, 8), Comentario = "Buen día en la playa", DireccionIP = "902.180.61.01", Inapropiado = 2, Likes = 4 });
            comentarios.Add(new Coment { ID = 4, Autor = "Rogelio", Fecha = new DateTime(2021, 5, 10), Comentario = "Gran fiesta la de hoy", DireccionIP = "902.160.61.15", Inapropiado = 1, Likes = 6 });


            
             ComentarioDB.SaveToFile(comentarios, @"C:\Users\sergi\Desktop\Notas\Comentarios.txt");*/
            
          
         
           Console.WriteLine("¿Desea agregar un comentario?");

             Console.WriteLine("Presione  *Y* para SI,  presione *N* para no ");

            try
            {
                string x = Console.ReadLine();

                if (x == "Y")
                {
                    try
                    {
                        List<Coment> NewComentario = new List<Coment>();
                        Console.WriteLine("ID: ");
                        int a = int.Parse(Console.ReadLine());
                        Console.WriteLine("Autor: ");
                        string b = Console.ReadLine();
                        Console.WriteLine("Fecha Obtenida\n");
                        DateTime c = DateTime.Today;
                        Console.WriteLine("Comentario: ");
                        string d = Console.ReadLine();
                        Console.WriteLine("Dirección IP: ");
                        string e = Console.ReadLine();
                        Console.WriteLine("Inapropiado: 0 ");
                        int f = 0;
                        Console.WriteLine("Likes: 0");
                        int g = 0;
                        NewComentario.Add(new Coment { ID = a, Autor = b, Fecha = c, Comentario = d, DireccionIP = e, Inapropiado = f, Likes = g });
                        ComentarioDB.NewComent(NewComentario, @"C:\Users\sergi\Desktop\Notas\Comentarios.txt");
                    }
                    catch (FormatException) { Console.WriteLine("El formato de los datos es incorrecto"); }

                }
            }
            catch (Exception) { }
            Console.WriteLine("============================================================\n");
            
            Console.WriteLine("¿Desea Interactuar con otros comentarios");
            Console.WriteLine("Presione  *Y* para SI,  presione *N* para no ");
            try
            {
                string Op = Console.ReadLine();

                if (Op == "Y")
                {
                    List<Coment> co = ComentarioDB.ReadFromFile(@"C:\Users\sergi\Desktop\Notas\Comentarios.txt");
                    
                    Console.WriteLine("Marca con una *I* un comentario inapropiado o con una *L* para dar un Like");
                    foreach (var c in co)
                    {
                        if (c.Inapropiado <= c.Likes)
                        {
                            Console.WriteLine(c);
                            Console.WriteLine("El comentario es: ");
                            string des = Console.ReadLine();
                            if (des == "i")
                                c.Inapropiado++;
                            else
                            {
                                c.Likes++;
                            }
                                
                        }
                    }
                    ComentarioDB.SaveToFile(co, @"C:\Users\sergi\Desktop\Notas\Comentarios.txt");
                }
            }
            catch (Exception) { }

            Console.WriteLine("============================================================\n");
            Console.WriteLine("¿Desea Borrar un comentario?");
            Console.WriteLine("Presione  *Y* para SI,  presione *N* para no ");

            try
            {
                string B = Console.ReadLine();
                List<Coment> com = ComentarioDB.ReadFromFile(@"C:\Users\sergi\Desktop\Notas\Comentarios.txt");
                if (B == "Y")
                {
                    Console.WriteLine("Digite el ID que desea borrar");
                    int identificador = int.Parse(Console.ReadLine());
                    identificador--;
                    com.RemoveAt(identificador);
                    ComentarioDB.SaveToFile(com, @"C:\Users\sergi\Desktop\Notas\Comentarios.txt");
                }
            }
            catch (FormatException) { }
            finally
            {
                Console.WriteLine("Ordenados por likes");
                ComentarioDB.GetLikes(@"C:\Users\sergi\Desktop\Notas\Comentarios.txt");

                Console.WriteLine("\nOrdenado por fecha");
                ComentarioDB.GetTime(@"C:\Users\sergi\Desktop\Notas\Comentarios.txt");
            }
        }
    }
}
