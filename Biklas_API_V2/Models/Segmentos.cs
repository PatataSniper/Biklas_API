//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Biklas_API_V2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Segmentos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Segmentos()
        {
            this.Alertas = new HashSet<Alertas>();
        }
    
        public int IdSegmento { get; set; }
        public int Posicion { get; set; }
        public int IdArista { get; set; }
        public int IdRuta { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alertas> Alertas { get; set; }
        public virtual Aristas Aristas { get; set; }
        public virtual Rutas Rutas { get; set; }
    }
}