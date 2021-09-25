using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodosWeb.Models
{
		public class Todo
		{
				[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
				[Required]
				public int Id { get; set; }

				[StringLength(200)]
				[Required]
				public string Task { get; set; }

				[DisplayName("Completed")]
				public bool IsCompleted { get; set; } = false;

				[Required]
				public DateTime Created { get; set; } = DateTime.Now;

				public override string ToString()
				{
						return $"{Id}, Task: {Task}, IsCompleted: {IsCompleted}";
				}

		}
}
