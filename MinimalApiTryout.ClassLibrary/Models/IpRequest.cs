using System.ComponentModel.DataAnnotations;
namespace MinimalApiTryout.ClassLibrary.Models;

public class IpRequest
{
	[Key]
	public int Id { get; set; }
	public string Ip { get; set; }
}
