namespace Proyecto_Final_Web_II.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Reservorio")]
    public partial class Reservorio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservorio()
        {
            Control = new HashSet<Control>();
        }

        [Key]
        public int reservorio_id { get; set; }

        public int sensor_id { get; set; }

        public int servo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string cant_agua_reser { get; set; }

        [Required]
        [StringLength(250)]
        public string dist_llenado_reser { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_reser { get; set; }

        [Required]
        [StringLength(20)]
        public string estado_reservorio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control> Control { get; set; }

        public virtual Sensor Sensor { get; set; }





        //metodo listar

        public List<Reservorio> listar() //retorna una coleccion de resgistro
        {
            var objreservorio = new List<Reservorio>();

            try
            {

                using (var db = new proyecto_ARTC())
                {
                    objreservorio = db.Reservorio.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objreservorio;
        }

        //metodo obtener

        public Reservorio obtener(int id) //retorna solo un objeto
        {
            var objreservorio = new Reservorio();

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    objreservorio = db.Reservorio.Where(x => x.reservorio_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objreservorio;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    if (this.reservorio_id > 0)
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
