# ProcessWatcher

Требуется написать приложение на C# WinForms, предназначенное для отображения списка 
процессов, выполняемых в данный момент в системе.\
В главной форме приложения в гриде нужно отображать постоянно обновляемый список 
исполняемых процессов.\
Необходимо обеспечить возможность получения расширенной информации для выбранного 
процесса.\
Получение информации по процессам должно происходить в отдельном потоке, его можно 
приостанавливать и продолжать.\
Код приложения должен быть безопасным как в смысле исключений, так и при работе с 
потоками.\
В процессе работы необходимо логгировать в текстовый файл все происходящие события 
(например, запрос пользователя на получение информации о процессе, приостановку и 
продолжение обновления списка процессов, появление нового процесса в списке, исчезновение 
процесса из списка и т.д.)\
Для решения задачи можно использовать как стандартные контролы Windows, так и любые 
сторонние компоненты.\
Отдельное внимание уделите интерфейсу пользователя, он должен быть удобным и аккуратным, 
несмотря на минимализм проекта.\
Свое решение необходимо выслать на этот адрес, в архив включить полный проект и отдельно 
скомпилированной приложение.