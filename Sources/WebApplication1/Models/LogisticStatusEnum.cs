using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public enum LogisticStatusEnum
{
    [Display(Name = "Prélèvement effectué", Order = 1)]
    Done,
    [Display(Name = "Expédié", Order = 2)]
    Shipped,
    [Display(Name = "Reçu", Order = 4)]
    Received,
    [Display(Name = "Prélèvement perdu par le transporteur", Order = 3)]
    Lost
}