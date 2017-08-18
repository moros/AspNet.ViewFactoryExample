namespace ViewFactoryExample.Factory
{
    public abstract class ViewModelFactory<TView, TInput>
        where TView : class
    {
        public abstract TView CreateView(TInput input);
    }

    public abstract class ViewModelFactory<TView>
        where TView : class
    {
        public abstract TView CreateView();
    }
}