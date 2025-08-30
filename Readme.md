Comandi Git:
1) Creare un nuovo ramo partendo da un ramo presente in origin 
        git fetch origin <remote-branch>
        git checkout -b <local-branch> origin/<remote-branch>

Esempio, da origin/development per i nuovi sviluppi 
        git fetch origin development
        git checkout -b dev/task_724 origin/development


2) Aggiungere nuovi files (Prima del commit)
        git add .

3) Fare push di un ramo locale su un nuovo ramo remoto omonimo
        git push -u origin <branch>
        git push -u  origin dev/task_724
