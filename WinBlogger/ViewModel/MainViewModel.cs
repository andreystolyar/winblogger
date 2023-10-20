﻿using System.Collections.ObjectModel;
using WinBlogger.Model;
using WinBlogger.UI.Data;

namespace WinBlogger.UI.ViewModel;

public class MainViewModel : ViewModelBase
{
  readonly IBloggerDataService _bloggerDataService;
	Blogger? _selectedAuthor;

	public MainViewModel(IBloggerDataService bloggerDataService)
	{
		Authors = new ObservableCollection<Blogger>();
		_bloggerDataService = bloggerDataService;
	}

	public void Load()
	{
		var bloggers = _bloggerDataService.GetAll();

		Authors.Clear();

		foreach (var blogger in bloggers)
			Authors.Add(blogger);
	}

	public bool CheckDb()
	{
		return _bloggerDataService.IsDbExists();
	}

	public void CreateDb()
	{
		_bloggerDataService.CreateDatabase();
	}

	public ObservableCollection<Blogger> Authors { get; set; }

	public Blogger? SelectedAuthor
	{
		get { return _selectedAuthor; }
		set
		{
			_selectedAuthor = value;
			OnNotifyPropertyChanged();
		}
	}
}
