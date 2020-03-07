#pragma once

using namespace WpfApp::ViewModel;

ref class MainWindowViewModel : MainWindowViewModelBase
{
public:
	MainWindowViewModel();

protected:
	void ProcessingThreshold() override;
};

