using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Tarea2.DAL;
using Tarea2.Entidades;

namespace Tarea2.BLL
{
    //En la BLL van los metodos que hara el programa con el contexto
    class PersonasBLL
    {
        
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //buscar la entidad que se desea eliminar
                var persona = contexto.Personas.Find(id);
                if (persona != null)
                {
                    contexto.Personas.Remove(persona);//remover la entidad mas las que enel agrego
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Personas Buscar(int Id)
        {
            Contexto contexto = new Contexto();
            Personas Persona;

            try
            {
                Persona = contexto.Personas.Find(Id);
            }
            catch (Exception)
            {

                throw;
            }
            contexto.Dispose();
            return Persona;


        }
        public static bool Guardar(Personas persona)
        {
            if (!Existe(persona.PersonaId))//si no existe insertamos
                return Insertar(persona);
            else
                return Modificar(persona);
        }
        public static bool Modificar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(persona).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Insertar(Personas persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                //ana te cuento un c=secreto
                contexto.Personas.Add(persona);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


            public static List<Personas> GetList(Expression<Func<Personas, bool>> expresion)
            {
                Contexto contexto = new Contexto();
                List<Personas> lista = new List<Personas>();
                try
                {
                    lista = contexto.Personas.Where(expresion).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                contexto.Dispose();
                return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Personas
                .Any(e => e.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado; //si
        }
    }
}
