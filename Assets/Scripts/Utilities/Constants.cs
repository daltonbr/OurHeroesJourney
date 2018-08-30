namespace Constants
{
    struct AnimationTuple
    {
        public string Parameter;
        public bool Value;

        public AnimationTuple(string parameter, bool value)
        {
            this.Parameter = parameter;
            this.Value = value;
        }

    }

    internal class AnimationTuples
    {
        internal static AnimationTuple IntroAnimation = new AnimationTuple("introAnimationIn", true);
        internal static AnimationTuple ExitAnimation = new AnimationTuple("introAnimationIn", false);
    }

}