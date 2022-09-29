using Application.Dto;
using Domain;

namespace Application.Converters
{
    public static class CookingStepExtention
    {
        public static CookingStepDto ConvertToCookingStepDto(this CookingStep cookingStep)
        {
            return new CookingStepDto
            {
                Id = cookingStep.Id,
                StepNumber = cookingStep.StepNumber,
                Description = cookingStep.Description,
                RecipeId = cookingStep.RecipeId
            };
        }
        public static CookingStep ConvertToCookingStep(this CookingStepDto cookingStepDto)
        {
            return new CookingStep
            {
                Id = cookingStepDto.Id,
                StepNumber = cookingStepDto.StepNumber,
                RecipeId = cookingStepDto.RecipeId,
                Description = cookingStepDto.Description
            };
        }
    }
}
