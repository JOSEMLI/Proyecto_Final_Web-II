namespace Proyecto_Final_Web_II.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Sensor")]
    public partial class Sensor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sensor()
        {
            Reservorio = new HashSet<Reservorio>();
        }

        [Key]
        public int sensor_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nomb_sensor { get; set; }

        public int aliment_sensor { get; set; }

        [Required]
        [StringLength(20)]
        public string rango_med_sensor { get; set; }

        public int frec_pul_sensor { get; set; }

        public int corr_ali_sensor { get; set; }

        public int apertura_sensor { get; set; }

        public int senal_disp_sensor { get; set; }

        [Required]
        [StringLength(8)]
        public string estado_sensor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservorio> Reservorio { get; set; }



        //metodo listar

        public List<Sensor> listar() //retorna una coleccion de resgistro
        {
            var objsensor = new List<Sensor>();

            try
            {

                using (var db = new proyecto_ARTC())
                {
                    objsensor = db.Sensor.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objsensor;
        }

        //metodo obtener

        public Sensor obtener(int id) //retorna solo un objeto
        {
            var objsensor = new Sensor();

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    objsensor = db.Sensor.Where(x => x.sensor_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objsensor;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    if (this.sensor_id > 0)
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
