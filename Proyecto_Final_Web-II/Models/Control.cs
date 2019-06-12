namespace Proyecto_Final_Web_II.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;

    [Table("Control")]
    public partial class Control
    {
        [Key]
        public int control_id { get; set; }

        public int reservorio_id { get; set; }

        public int servo_id { get; set; }

        public int usuario_id { get; set; }

        [Required]
        [StringLength(1)]
        public string servo_control { get; set; }

        [Column(TypeName = "date")]
        public DateTime fecha_control { get; set; }

        [Required]
        [StringLength(20)]
        public string estado_control { get; set; }

        public virtual Reservorio Reservorio { get; set; }

        public virtual Servo Servo { get; set; }

        public virtual Usuario Usuario { get; set; }


        //metodo listar

        public List<Control> listar() //retorna una coleccion de resgistro
        {
            var objcontrol = new List<Control>();

            try
            {

                using (var db = new proyecto_ARTC())
                {
                    objcontrol = db.Control.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objcontrol;
        }

        //metodo obtener

        public Control obtener(int id) //retorna solo un objeto
        {
            var objcontrol = new Control();

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    objcontrol = db.Control.Where(x => x.control_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objcontrol;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    if (this.control_id > 0)
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
