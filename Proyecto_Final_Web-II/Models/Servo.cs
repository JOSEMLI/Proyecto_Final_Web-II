namespace Proyecto_Final_Web_II.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Servo")]
    public partial class Servo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servo()
        {
            Control = new HashSet<Control>();
        }

        [Key]
        public int servo_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nomb_servo { get; set; }

        [Required]
        [StringLength(250)]
        public string torque_servo { get; set; }

        [Required]
        [StringLength(250)]
        public string dimens_servo { get; set; }

        [Required]
        [StringLength(250)]
        public string voltaje_servo { get; set; }

        public decimal vel_mov_servo { get; set; }

        public decimal peso_servo { get; set; }

        [Required]
        [StringLength(8)]
        public string estado_servo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control> Control { get; set; }




        //metodo listar

        public List<Servo> listar() //retorna una coleccion de resgistro
        {
            var objservo = new List<Servo>();

            try
            {

                using (var db = new proyecto_ARTC())
                {
                    objservo = db.Servo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objservo;
        }

        //metodo obtener

        public Servo obtener(int id) //retorna solo un objeto
        {
            var objservo = new Servo();

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    objservo = db.Servo.Where(x => x.servo_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objservo;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    if (this.servo_id > 0)
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
