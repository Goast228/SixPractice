   M S B A M L   `   `   `  ????G  CGoodsCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:GoodsCompanyGoodsCompany  5   	       GoodsCompany.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:GoodsCompany     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ? .+?5   
   ?  ? RowDefinitions 5      ?? 5      $??60 ?6    ?? 5      $??30 ?6    ?? 5      $??* ?6    ?? 5      $??50 ?6    .+?5      ? $??0??6   ???	#FF9192FF6    ?? 5      -   5         ??Name$ BtnBack??5      $??0??6&   $??
Назад??63   $??Right=?6C   ???	#FF00B3006u   ?? 5      -   5         ??Name$ NameProject??5      $??0??6-   $%??Компания товаров??6:   $??Center=?6R   ? 5      $??1??6   ???	#FFC4EBFF6    o? 5      -   5         o?Name$ ProjectMenu??5      $??1??6(   ???	#FFC4EBFF$
??Left=?6L   ???#000$??1q?6z   .@?5      m? $*??$Операции с проектом??6   $	??400??68   .@?5      ?? -   5        $ SeeGoodsBtn??5      $)??#Просмотреть товары??62   $	??350??6O   $
??Left=?6[   
?????? $??0q?6?   6?   ?? 5      -   5        $ SeeSupervisorBtn??5      $7??1Просмотреть руководителей??67   $	??350??6[   $
??Left=?6g   
?????? $??0q?6?   6?   ?? 5      -   5        $ SeeCompanyBtn??5      $-??'Просмотреть компании??64   $	??350??6S   $
??Left=?6_   
?????? $??0q?6?   6?   ?? 5      ?? 5      -   5        $ WordGoodBtn??5      $E???Сгенерировать документ по товарам??62   $	??350??6^   $
??Left=?6j   
?????? $??0q?6?   6?   ?? 5      -   5        $ WordSupervisorBtn??5      $Q??KСгенерировать документ по руководителям??68   $	??350??6j   $
??Left=?6v   
?????? $??0q?6?   6?   ?? 5       -	   5        $ WordCompanyBtn??5       $I??CСгенерировать документ по компаниям??65   $	??350??6c   $
??Left=?6o   
?????? $??0q?6?   6?   5!      5"       ? 5$      -
   5          ?Name$ 	MainFrame??5$      $??2??6'     ? NavigationUIVisibility$ Hidden=?64   6T   ? 5&      $??3??6   ???	#FFC4EBFF6    5(      5)      5*      