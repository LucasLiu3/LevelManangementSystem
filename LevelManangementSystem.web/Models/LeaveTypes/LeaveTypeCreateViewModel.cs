using System.ComponentModel.DataAnnotations;

namespace LevelManangementSystem.web.Models.LeaveTypes
{
    public class LeaveTypeCreateViewModel
    {

        //当view里面没有JavaScript的时候或者JavaScript不能覆盖全面的validation的时候，那么Model.state就会显示这里的错误信息
        [Required]
        [Length(4,150,ErrorMessage = "Input between 4 and 150 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Range(1,30,ErrorMessage ="Input numbers between 1 and 30")]
        [Display(Name = "USE THIS WILL CHANGE THE NAME")]   //设定这个，在用这个viewmodel的view里面，这个字段名的显示就会显示自设定的名字
        public int NumberOfDays { get; set; }
    }
}
