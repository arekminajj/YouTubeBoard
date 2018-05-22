using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YouTubeBoardCore.Models
{
	public class VideoModel
    {
	    public int Id { get; set; }
		[Required]
	    public string Name { get; set; }
		[Required]
	    public string Description { get; set; }
	    public DateTime Created { get; set; }
		[Required]
		[Display(Name = "Video Url")]
		[MaxLength(100)]
		[MinLength(30)]
	    public string Url { get; set; }
	    public string UserName { get; set; }
		public string UserEmail { get; set; }
    }
}
