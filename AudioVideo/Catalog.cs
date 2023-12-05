//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AudioVideo
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    public partial class Catalog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalog()
        {
            this.Sale = new HashSet<Sale>();
        }
    
        public int CatalogID { get; set; }
        public string Name { get; set; }
        public int TechniqueTypeID { get; set; }
        public string TechniqueName { 
            get {
                return TechniqueType.Type.ToString();
            } 
        }
        public System.DateTime ReceiptDate { get; set; }
        public int Amount { get; set; }
        public int SellingPrice { get; set; }
        public byte[] Image { get; set; }
        public byte[] CorrectImage
        {
            get
            {
                if (Image == null)
                    return File.ReadAllBytes("../../Resources/Picture.png");
                else return Image;
            }
        }

        public string AdminVisibility
        {
            get
            {
                if (App.CurrentUser == null)
                    return "Hidden";                
                else if (App.CurrentUser.RoleID == 2)
                    return "Hidden";
                else return "Visible";
            }
        }
    
        public virtual TechniqueType TechniqueType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
