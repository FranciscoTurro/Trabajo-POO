
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Modelo
{

using System;
    using System.Collections.Generic;
    
public partial class Permiso
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Permiso()
    {

        this.Formulario = new HashSet<Formulario>();

    }


    public int Id { get; set; }

    public string Nombre { get; set; }

    public string NombreSistema { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Formulario> Formulario { get; set; }

}

}
