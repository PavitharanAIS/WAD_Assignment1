using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SSR.Models.Models
{
    public class MenuItems
    {
        [Key] // This is used to make sure that public int Id is the primary key in this table. Note: [Key] is not required if the column name is Id or anytext followed by Id, but [Key has to be mentioned if the column name contains any special symbol or numbers in it along with Id.]
        public int Id { get; set; }
        [MaxLength(30)] // MaxLength is used to set the maximum number of characters that the name field can contain.
        [Required] //[XXX] These are called Annotations. [Required] sets the field to a compulsory field.
        [DisplayName("Menu Name")] //SisplayName Annotation is used to Display the class names in view wherever required as we prefer. You can see its use in CreateMenu.cshtml -> asp-for="Name" -> Displays the name that we entered here to the view without the use of a label text.
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage = "The field Display Order must be between 1 - 100.")] //Range is used to set the max numer of interger value that can be entered in the field. ErrorMessage is used to display what error should be shown to the user if the entered value is not between 1-100.
        public int DisplayOrder { get; set; }   
    }
}
