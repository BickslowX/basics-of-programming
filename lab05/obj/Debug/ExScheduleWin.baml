   M S B A M L   `   `   `  ����D  @znoSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:znoSystem	znoSystem  5   	       znoSystem.ExScheduleWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:znoSystem     5   	     � Title$'  !Розклад Екзаменів��5   	   $	��576��6#   $
��1500��60   ���	#FF02231C � WindowStartupLocation$ CenterScreen=�6T    � 
ResizeMode$ NoResize=�6y   .��5	      � .+�5
   
   �� -   5         ��Name$ AbitIDTB��5
      $
��Left=�6$   $��
171,36,0,0q�6?    �� TextWrapping$
 Wrap=�6S   $	��Top=�6g   $	��123��6   $��24��6�   $��Algerian)�6�   $
��Bold"�6�   $��Italic$�6�   $��14(�6   �� TextDecorations 6�   Z� 6  &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	AbitEx1DG��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6&   $��171,113,19,375q�6a   $��Disabled=�6y   "   VerticalScrollBarVisibility$ Disabled=�6�   ��.  $��Algerian)�6�   $��14(�6  $
��Bold"�6  $��Normal$�60  $	   HorizontalScrollBarVisibility$	 Disabled=�6C  �� 5   
   $ ��ID Абітурієнта:��6   $
��Left=�6*   $��28��6E   $��	20,34,0,0q�6Q   $	��Top=�6d   $	��154��6|   ���	#FFC7F6EC$��Algerian)�6�   $��16(�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   $��Екзамен 1:��6   $
��Left=�6%   $��28��6@   $��
46,113,0,0q�6L   $	��Top=�6`   $	��102��6x   ���	#FFC7F6EC$��Algerian)�6�   $��16(�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   $��Екзамен 2:��6   $
��Left=�6%   $��28��6@   $��
46,207,0,0q�6L   $	��Top=�6`   $	��102��6x   ���	#FFC7F6EC$��Algerian)�6�   $��16(�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   $��Екзамен 3:��6   $
��Left=�6%   $��28��6@   $��
46,300,0,0q�6L   $	��Top=�6`   $	��102��6x   ���	#FFC7F6EC$��Algerian)�6�   $��16(�6�   $
��Bold"�6�   $��Italic$�6�   
 J� RenderTransformOrigin$
 
0.48,1.544&�6�     5   
   -   5        $ 	AbitEx2DG��5      $ * 6&   $��171,207,19,280q�6a   $��Disabled=�6y   $ Disabled=�6�   ��.  $��Algerian)�6�   $��14(�6  $
��Bold"�6  $��Normal$�60  $	 Disabled=�6C    5   
   -   5        $ 	AbitEx3DG��5      $ * 6&   $��171,300,19,187q�6a   $��Disabled=�6y   $ Disabled=�6�   ��.  $��Algerian)�6�   $��14(�6  $
��Bold"�6  $��Normal$�60  $	 Disabled=�6C  �� 5   
   -   5         ��Name$ AbitSNP��5      $�� ��6!   $
��Left=�6,   $��
171,80,0,0q�6G   $	��Top=�6[   ���	#FFF6F7F9$��Algerian)�6�   $��14(�6�   $
��Bold"�6�   $��Italic$�6�   �� 5   
   -   5         ��Name$ 
ESWBackBtn��5      $��Повернутися��6%   $
��Left=�6;   $��
64,414,0,0q�6V   $	��Top=�6j   $��78��6�   $	��192��6�   ���	#FF0C2D26���	#FFC7F6EC$��18(�6�   $
��Bold"�6�   $��Algerian)�6�   6�   5      5      