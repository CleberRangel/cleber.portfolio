using NUnit.Framework;

namespace WpfBuildWithSquirrel.Test
{
    [TestFixture]
    public class MainViewModelTest
    {

        [Test]
        public void Should_Disable_AtStart()
        {
            var viewModel = new MainViewModel("https://github.com/CleberRangel/cleber.portfolio");

            Assert.That(viewModel.UpdateApplicationCommand.CanExecute(null), Is.False);

            viewModel.CheckUpdateCommand.Execute(null);

        }
    }
}