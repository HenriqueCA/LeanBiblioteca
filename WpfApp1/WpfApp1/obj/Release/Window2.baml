   M S B A M L   `   `   `  ���� B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1      WpfApp1.Window2   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:WpfApp1       � Title$  Window2�� � WindowState$ 	Maximized=� � WindowStyle$
 None=� � 	Resources    TwCenMt �� Property �� Value  PasswordBoxControlTemplate1 �� 
TargetType ��Name �� CornerRadius	 J� SnapsToDevicePixels
 ��Name �� Triggers P� Property P� Value �� 
TargetName  ButtonControlTemplate1 ��Name �� ContentStringFormat �� ContentStringFormat��%�  &	        &	 2     &	 �    �� .���  � ��$ Resources/#tw-cen-mt-6)��� " G�.R��� $ border��$ 5��#��z��#��z��#��z��	 . ._��� $
 PART_ContentHost��|�.  $��Hidden=�$��Hidden=� P�  � {� .  . ��� $ border�� �@J�Opacity$
 0.56Q�P�  �@J�IsMouseOver . . ��� $ border�� � �� �	#FF7EB4EAP�  �@J�IsKeyboardFocused . . ��� $ border�� � �� �	#FF569DE5�� " ��.R��� $ border��$ 5��#��z��#��z��#��z��	 . ._��� $ contentPresenter��#��z��#��z��# z |�.  #��z��#��z����. #	 z	 #��z�� P�  �@��IsDefaulted . . ��� $ border��# � �� � ��P�  �@J�IsMouseOver . P�  � �� . P�  �@d�	IsChecked$
 TrueY�. ��� $ border�� � �� �	#FFBCDDEE�� $ border�� � �� �	#FF245A83P�  � {� .  . ��� $ border�� � �� �	#FFF4F4F4�� $ border�� � �� �	#FFADB2B5�� $ contentPresenter�� � �� �	#FF838383.��� #���    � ColumnDefinitions �� $
��279* ��� $	��16* ��� $	��15* ��� $
��110* ��� $	��19* ��� $	��14* ��� $��5* ��� $
��114* ��� $
��173* ��� $	��15* � � RowDefinitions �� $
��141* ��� $	��34* ��� $��3* ��� $	��24* ��� $��5* ��� $	��24* ��� $��3* ��� $	��34* ��� $��5* ��� $	��24* ��� $��5* ��� $	��24* ��� $��5* ��� $	��34* ��� $��5* ��� $	��24* ��� $��4* ��� $	��24* ��� $	��70* ��� $	��26* ��� $��9* �����  �� ImageSource ��  �� 	UriSource$A ;file:///C:/Users/Henri/Downloads/SISTEMOTECA/background.jpg?�.+��� $��Digite seu CPF:��
�������$��20(�$��1��$��2��$��3��$��Center=�$��Stretch=��� -    ��Name$ 	CpfSearch�� �� TextWrapping$
 Wrap=�$�� ��$��0q�$��Center=�$��20(�$��3��$��1��$��5��$��1��.��  �� 
TargetType��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.���� -    ��Name$ SearchButton��#���  $��PROCURAR��$��0q� � Cursor$
 Hand��
����������	#FF373C95
�������$��5��$��3�� �� 	IsDefault . $��1����.  �� -    ��Name$ CpfNotRegistered��$��Cpf não cadastrado�����	#FFFF0404 J� RenderTransformOrigin$ 0.419,0.655&�$��3��$��7��$��50��$��24��$��Center=�$y�Hidden=��� -   $ SecretQuestion��$�� ��
�������$��20(�$��7��$��9��$��Center=�$��Center=�$��	-15,0,0,0q��� -   $ Answer��$
 Wrap=�$�� ��$��0q�$��Center=�$��20(�$��9��$��1��$��5��$y�Hidden=�{�.  $��2��.�� ��%9   '��       �� " ��.���  �@��CornerRadius$ 5��.���� -   $ IncorrectAnswer��$��Resposta incorreta�����	#FFFF0404$ 0.419,0.655&�$��9��$��7��$��50��$��24��$��Center=�$y�Hidden=��� -   $ NovaSenhaLabel��$��Nova senha:��
�������$��20(�$��Center=�$��Center=�$��13��$��34��$	��144��$��2��$��3��$��Center=�$��Stretch=�$y�Hidden=��� -   $ AnswerButton��#���  $��CONFIRMA��$��0q�$
 Hand��
����������	#FF373C95
�������$��11��$��3��$y�Hidden=�{�.  ��.  �� -	   $ ChangeButton��#���  $��MUDAR��$��0q�$
 Hand��
����������	#FF373C95
�������$��17��$��3��$y�Hidden=�{�.  ��.  G� -
    G�Name$ NewPassword��#���  $��0q�$��Center=�$��3��$��20(� G� 	MaxLength$ 20��$��15��$��1��$��5��{�.  $y�Hidden=��� -   $ InvalidPassword��$��Senha inválida�����	#FFFF0404$ 0.419,0.655&�$��15��$��7��$��50��$��24��$��Center=�$y�Hidden=�$��0q�$��1���� -   $ ExitNewPasswordButton��#���  $
��SAIR��$��0q�$
 Hand��
����������	#FF373C95
�������$��19��$��3��$��40����.  