namespace Proyecto_Final_Web_II.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int persona_id { get; set; }

        [Required]
        [StringLength(3)]
        public string cod_per { get; set; }

        [Required]
        [StringLength(250)]
        public string nomb_per { get; set; }

        [Required]
        [StringLength(250)]
        public string apel_per { get; set; }

        [Required]
        [StringLength(2)]
        public string edad_per { get; set; }

        [Required]
        [StringLength(8)]
        public string dni_per { get; set; }

        [Required]
        [StringLength(1)]
        public string sexo_per { get; set; }

        [StringLength(11)]
        public string cel_per { get; set; }

        [Required]
        [StringLength(8)]
        public string estado_per { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }




        //metodo listar

        public List<Persona> listar() //retorna una coleccion de resgistro
        {
            var objpersona = new List<Persona>();

            try
            {

                using (var db = new proyecto_ARTC())
                {
                    objpersona = db.Persona.Include("usuario").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objpersona;
        }

        //metodo obtener

        public Persona obtener(int id) //retorna solo un objeto
        {
            var objpersona = new Persona();

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    objpersona = db.Persona.Include("usuario").Where(x => x.persona_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objpersona;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    if (this.persona_id > 0)
                    {
                        //si existe un valor mayor a cero es porque exiiste el registro
                        db.Entry(this).State = EntityState.Modified;

                    }
                    else
                    {
                        //si no existe el registro lo graba(nuevo)
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //metodo eliminar

        public void eliminar()
        {
            try
            {
                using (var db = new proyecto_ARTC())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




    }
}
