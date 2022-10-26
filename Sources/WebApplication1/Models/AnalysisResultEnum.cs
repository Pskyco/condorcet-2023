using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public enum AnalysisResultEnum
{
    [Display(Name = "Positif")]
    Positive,
    [Display(Name = "Négatif")]
    Negative,
    [Display(Name = "Non concluant")]
    NonConclusive,
}