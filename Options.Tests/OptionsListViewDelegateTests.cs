using System;
using System.Linq;
using FluentAssertions;
using Options.Core;
using Options.Forms.Adapters;
using Xunit;
using Xunit.Abstractions;

namespace Options.Tests
{
    public class OptionsListViewDelegateTests : IDisposable
    {
        private readonly OptionsListViewDelegate _sut;
        private          Watcher                 _watcher;

        public OptionsListViewDelegateTests(ITestOutputHelper output)
        {
            _sut     = new OptionsListViewDelegate(source: null);
            _watcher = new Watcher(output);
        }

        [Fact]
        public void Given_ListViewSourceChanged_ShouldUpdateDelegateSource()
        {
            //Arrange
            var newSource = new Core.Options();
            newSource.AddRange(Enumerable.Repeat(new Option("Title"), 1000));

            //Act
            _watcher.Start();

            _sut.UpdateSource(newSource);

            _watcher.Record();

            //Assert
            _sut.Source.Should().BeEquivalentTo(newSource);
        }

        [Fact]
        public void Given_NullAsNewSource_ShouldUpdateDelegateSource()
        {
            //Act
            _sut.UpdateSource(source: null);

            //Assert
            _sut.Source.Should().BeNull();
        }

        [Fact]
        public void Given_NullAsSelectedOption_ShouldNotThrowException()
        {
            //Arrange
            Action sut = () => _sut.UpdateOptionState(selectedOption: null);

            //Act & Assert
            sut.Should().NotThrow();
        }

        [Fact]
        public void Given_MultipleSelection_ShouldUpdateOptionState_AndNotResetOthers()
        {
            //Arrange
            var newSource = new Core.Options(multipleSelection: true);
            newSource.AddRange(Enumerable.Repeat(new Option("Option") {IsSelected = true}, 10));

            var optionToSelect = new Option("Option");
            newSource.Add(optionToSelect);

            _sut.UpdateSource(newSource);

            //Act
            _watcher.Start();

            _sut.UpdateOptionState(optionToSelect);

            _watcher.Record();

            //Assert
            optionToSelect.IsSelected.Should().BeTrue();
            _sut.Source.Select(x => x.IsSelected.Should().BeTrue()).All(x => true);
        }

        [Fact]
        public void Given_SingleSelection_ShouldUpdateOptionState_AndResetOthers()
        {
            //Arrange
            var newSource = new Core.Options();
            newSource.AddRange(Enumerable.Repeat(new Option("Option") {IsSelected = true}, 10));

            var optionToSelect = new Option("Option");
            newSource.Add(optionToSelect);

            _sut.UpdateSource(newSource);

            //Act
            _watcher.Start();

            _sut.UpdateOptionState(optionToSelect);

            _watcher.Record();

            //Assert
            optionToSelect.IsSelected.Should().BeTrue();
            _sut.Source.Where(x => x != optionToSelect).Select(x => x.IsSelected.Should().BeFalse()).All(x => true);
        }

        public void Dispose()
        {
            _watcher = null;
        }
    }
}