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
        [Display(Name = "Dosage")]
        public Dosage DosageValue { get; set; }
        [Required]
        [Display(Name = "Frequency")]
        public Freq FrequencyValue { get; set; }
        public string Notes { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public enum Dosage
        {
            FiveMG = 1,
            TenMG = 2,
            TwentyMG = 3,
            FiftyMG = 4,
            OneHundredMG = 5,
            TwoHundredFiftyMG = 6,
            FiveHundredMG = 7
        }
        public enum Freq
        {
            Daily = 1,
            TwiceDaily = 2,
            ThreeTimesDaily = 3,
            FourTimesDaily = 4,
            Hourly = 5,
            EveryFourHours = 6,
            EverySixHours = 7,
            EveryEightHours = 8,
            EveryTwelveHours = 9
        }
    }
}