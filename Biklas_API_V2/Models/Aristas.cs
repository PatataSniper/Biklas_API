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
    
    public partial class Aristas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aristas()
        {
            this.Segmentos = new HashSet<Segmentos>();
        }
    
        public int IdArista { get; set; }
        public int NumeroCarriles1 { get; set; }
        public Nullable<int> NumeroCarriles2 { get; set; }
        public bool Bidireccional { get; set; }
        public int IdVerticeInicial { get; set; }
        public int IdVerticeFinal { get; set; }
        public int IdVia { get; set; }
    
        public virtual Vertices Vertices { get; set; }
        public virtual Vertices Vertices1 { get; set; }
        public virtual Vias Vias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Segmentos> Segmentos { get; set; }
    }
}