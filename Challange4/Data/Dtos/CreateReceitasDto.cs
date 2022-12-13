﻿using System.ComponentModel.DataAnnotations;

namespace Challange4.Data.Dtos
{
    public class CreateReceitasDto
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }

     
    }


   
}
