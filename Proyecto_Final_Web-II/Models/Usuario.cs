namespace Proyecto_Final_Web_II.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    using System.Linq;
    using System.Data.Entity;


    using System.Data.Entity.Validation;
    using System.Web;
    using System.IO;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Control = new HashSet<Control>();
        }

        [Key]
        public int usuario_id { get; set; }

        public int persona_id { get; set; }

        [Required]
        [StringLength(50)]
        public string nomb_usu { get; set; }

        [Required]
        [StringLength(80)]
        public string pas_usu { get; set; }

        [Required]
        [StringLength(20)]
        public string nivel_usu { get; set; }

        [Required]
        [StringLength(250)]
        public string foto_usu { get; set; }

        [Required]
        [StringLength(10)]
        public string estado_usu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control> Control { get; set; }

        public virtual Persona Persona { get; set; }



        //metodo listar

        public List<Usuario> listar() //retorna una coleccion de resgistro
        {
            var objusuario = new List<Usuario>();

            try
            {

                using (var db = new proyecto_ARTC())
                {
                    objusuario = db.Usuario.Include("persona").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objusuario;
        }

        //metodo obtener

        public Usuario obtener(int id) //retorna solo un objeto
        {
            var objusuario = new Usuario();

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    objusuario = db.Usuario.Include("persona").Where(x => x.usuario_id == id).SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return objusuario;
        }


        // metodo guardar

        public void guardar()
        {

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    if (this.usuario_id > 0)
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



        // metodo validar login

        public ResponseModel validarlogin(string usuarios, string Password)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db = new proyecto_ARTC())
                {
                    Password = HashHelper.MD5(Password);
                    var usuario = db.Usuario.Where(x => x.nomb_usu == usuarios)
                                            .Where(x => x.pas_usu == Password)
                                            .SingleOrDefault();

                    if (usuario != null)
                    {
                        SessionHelper.AddUserToSession(usuario.usuario_id.ToString());
                        rm.SetResponse(true);
                    }
                    else
                    {
                        rm.SetResponse(false, "Usuaro y/o password son incorrectos ....");
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }


        ////metodo guardar perfil

        public ResponseModel guardarperfil(HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new proyecto_ARTC())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;

                    var usu = db.Entry(this);
                    usu.State = EntityState.Modified; //permite modificar el usuario

                    if (foto != null)
                    {
                        string extension = Path.GetExtension(foto.FileName).ToLower(); //el path me permite obtener algunas propiedades del archivo

                        int size = 1024 * 1014 * 5; //es el tamaño que recibe 
                        var filtroextension = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var extensiones = Path.GetExtension(foto.FileName); //la foto

                        if (filtroextension.Contains(extensiones) && (foto.ContentLength <= size))
                        {
                            string archivo = Path.GetFileName(foto.FileName);//es lo que vamos a obtener

                            //la ruta doonde guardaremos las imagenes
                            foto.SaveAs(HttpContext.Current.Server.MapPath("~/fotousu/" + archivo));
                            this.foto_usu = archivo;

                        }

                    }
                    else usu.Property(x => x.foto_usu).IsModified = false;

                    if (this.usuario_id == 0) usu.Property(x => x.usuario_id).IsModified = false;
                    if (this.persona_id == 0) usu.Property(x => x.persona_id).IsModified = false;
                    if (this.nomb_usu == null) usu.Property(x => x.nomb_usu).IsModified = false;
                    if (this.pas_usu == null) usu.Property(x => x.pas_usu).IsModified = false;
                    if (this.nivel_usu == null) usu.Property(x => x.nivel_usu).IsModified = false;
                    if (this.estado_usu == null) usu.Property(x => x.estado_usu).IsModified = false;

                    db.SaveChanges();
                    rm.SetResponse(true);

                }
            }
            catch (DbEntityValidationException e)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return rm;
        }



    }
}
