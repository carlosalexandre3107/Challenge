   M S B A M L   `   `   `  ����G  CAppGitHubApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AppGitHubApiAppGitHubApi  5   	       AppGitHubApi.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:AppGitHubApi     5   	     � Title$&   Busca de repositórios do GitHub��5   	   $	��350��61   $	��500��6>   $��R)�6J   $��Center=�6Y   $��Center=�6v   .��5	      � .+�5
   
   �� -   5         ��Name$ login��5
      $��Login do GitHub��6   $
��Left=�69   $��	22,10,0,0q�6T   $	��Top=�6g   �� 5   
   -   5         ��Name$ LoginDoGitHub��5      $
��Left=�6)   $��	28,34,0,0q�6D    �� TextWrapping$
 Wrap=�6W   $	��Top=�6k   $	��343��6�   �� 5   
   -   5        $ senha��5      $��Senha:
��6   $
��Left=�6:   $��	28,63,0,0q�6U   $	��Top=�6h   $��22��6�   G� 5   
   -   5         G�Name$ SenhaDoGitHub��5      $
��Left=�6-   $��	28,88,0,0q�6H   $	��Top=�6[   $	��343��6s    J� RenderTransformOrigin$ 
0.28,1.222&�6   �� 5   
   -   5         ��Name$ buttonLogar��5      $��Logar��6&   $
��Left=�66   $��
394,88,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5        $ labelUsuarioGitHub��5      $��Nome do usuário GitHub��6,   $
��Left=�6M   $��
28,117,0,0q�6h   $	��Top=�6|   $y�Hidden=�6�   �� 5   
   -   5        $ NomeUsuarioGitHub��5      $
��Left=�6-   $��
28,141,0,0q�6H   $
 Wrap=�6\   $	��Top=�6p   $	��343��6�   $y�Hidden=�6�   �� 5   
   -   5        $ buttonBuscar��5      $��Buscar��6'   $
��Left=�68   $��394,141,0,0q�6S   $	��Top=�6h   $��75��6�   $y�Hidden=�6�   6�   �� 5   
   -	   5        $ labelListaDeRepositorios��5      $��Lista de Repositórios��62   $
��Left=�6R   $��
28,177,0,0q�6m   $	��Top=�6�   $y�Hidden=�6�   &   System.Windows.Controls.DataGrid  5   
   -
   5          Name$ dataGridRepositorios��5      $
��Left=�61   $��
28,201,0,0q�6L   $	��Top=�6`   $��97��6x   $	��441��6�      FrozenColumnCount$ 1��6�   $y�Hidden=�6�   	   AutoGenerateColumns	 .  
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Id+   ClipboardContentBinding 6<   Z� 6_     5      $
 Nome��6a    6%   �� *Nome+ 6>   Z� 6a     5      $	 Url��6`    6%   �� *Url+ 6=   Z� 6`   5      5      5      