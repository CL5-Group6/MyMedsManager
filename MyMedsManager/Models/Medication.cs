using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MyMedsManager.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Medicine { get; set; }
        [Required]
        public int MedQuantity { get; set; }
        [Required]
        public string Dosage { get; set; }
        public string Notes { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
    }
}