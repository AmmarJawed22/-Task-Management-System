using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementSystem.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Name_Title { get; set; }
        public string Description { get; set; }
        public string Assignee { get; set; }
        public DateTime Deadline { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}
