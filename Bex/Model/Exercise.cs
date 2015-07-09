using Newtonsoft.Json;

namespace Bex.Model
{
    public class Exercise : ActivityBase
    {
        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }

        [JsonProperty("stringId")]
        public string StringId { get; set; }

        [JsonProperty("exerciseId")]
        public int ExerciseId { get; set; }

        [JsonProperty("doNotCount")]
        public bool DoNotCount { get; set; }

        [JsonProperty("useAccelerometer")]
        public bool UseAccelerometer { get; set; }

        [JsonProperty("useGPS")]
        public bool UseGps { get; set; }

        [JsonProperty("useWeight")]
        public bool UseWeight { get; set; }

        [JsonProperty("useCustomaryUnits")]
        public bool UseCustomaryUnits { get; set; }

        [JsonProperty("countableId")]
        public int CountableId { get; set; }

        [JsonProperty("weight")]
        public int Weight { get; set; }

        [JsonProperty("exerciseType")]
        public int ExerciseType { get; set; }

        [JsonProperty("exerciseCategory")]
        public string ExerciseCategory { get; set; }

        [JsonProperty("completionType")]
        public int CompletionType { get; set; }

        [JsonProperty("completionValue")]
        public int CompletionValue { get; set; }

        [JsonProperty("computedCompletionValue")]
        public int ComputedCompletionValue { get; set; }

        [JsonProperty("weightUsed")]
        public int WeightUsed { get; set; }

        [JsonProperty("userCompletionValue")]
        public int UserCompletionValue { get; set; }

        [JsonProperty("kExerciseTraversalType")]
        public int KExerciseTraversalType { get; set; }

        [JsonProperty("exerciseFinishStatus")]
        public int ExerciseFinishStatus { get; set; }

        [JsonProperty("isRest")]
        public bool IsRest { get; set; }

        [JsonProperty("pausedTime")]
        public string PausedTime { get; set; }
    }
}