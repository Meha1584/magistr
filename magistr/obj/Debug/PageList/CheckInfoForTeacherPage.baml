   M S B A M L   `   `   `  ����B  >magistr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:magistr.PageListmagistr.PageList  5      .    (magistr.PageList.CheckInfoForTeacherPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:magistr.PageList     5        N� Title$  CheckInfoForTeacherPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      $��2* �6   �� 5      $��2* �6   .+�5   
   �  � Orientation$ 
Horizontal=�6   $��1��6-   .+�5      �� $(��"Данные о студентах��6   &   System.Windows.Controls.DataGrid  5      -   5        $��dataStudent��5   3      AutoGenerateColumns .  "   VerticalScrollBarVisibility$
 Auto=�6F      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ФИО��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 66   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6@   �� *
FioStudent+6_     5      $ ФИО родителей��6)   $ * 6@   	 . 
 6J   �� *FullNameOfTheParent+6r     5      $ Телефон��6)   $ * 6:   	 . 
 6D   �� *NumberPhone+6d     5      $ Посещаемость��6)   $ * 6?   
 6I   �� *
Attendance+  5      $) #Причина отсутствия��6)   $ * 6E   
 6O   �� *ReasonforAbsence+  5      $ % усваемости��6)   $ * 6?   
 6I   �� *PercentageOfEarnedMaterial+  5      $ Курс��6)   $ * 67   	 . 
 6A   �� *Title+6[   5!      �� 5"      $��Right=�6   .+�5#      �� -   5        $+��%Сохранить изменения��5#      67   5$      5%      �� 5&   
   -   5        $��nameTeacher��5&   (   $ ��Преподаватель��6   $��20q�6;   $��22(�6G   �� 5'   
   $��1��6   $��1��6%   $��20q�62   .+�5(      �� $��Выбор даты��6   �� 5)      -   5        $��	checkDate��5)      6(   �� 5*      $
��0,10q�6   .+�5+      �� $!��Поиск студента��6   �� 5,      -   5        $��findTeacher��5,      6-   5-      �� 5.      $��Выбор курса��6   �� 5/      -   5        $��
filterWell��5/      6)   50      � 51   
   $��2��6   $	��200��6!   $	��500��6.   $
��Left=�6:   .+�52      � $	��Top=�6   $
��Left=�60   .+�53        -   5        $��dataWell��53   7    .  $
 Auto=�6G   $	��300��6j    54        55      $ Номер курса��6-   $ * 6B   
 6L   �� *idWell+  56      $! Название курса��6-   $ * 6E   
 6O   �� *title+4  .System.Windows.Controls.DataGridTemplateColumn  57      $ * 61   $ Просмотр��6;      CellTemplate 58      �� 59   "   .R�5:   &   �� -   5        $��Просмотреть��5:   -   6C   5;   #   5=      5?      5@      �� 5A      $
��10,0q�6   .+�5B      �� $��Поиск курса��6   �� 5C      -	   5        $��findWell��5C      6*   5D      5E      �� 5F   
   $��2��6   $��1��6"   .+�5G      �� .+�5H      �� $%��Описание занятия��6   �� 5I      -
   5        $��descriptionActivity��5I      $
��Wrap=�67   $	��100��6K   
�������6X   5J      �� 5K      $��Center=�6   $
��0,30q�66   .+�5L      �� -   5        $��Создать курс��5L      60   �� 5M      -   5        $��
Отчет��5M      $��0,10,0,0q�6>   5N      5O      5P      5Q      