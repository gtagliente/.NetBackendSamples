Comandi Git:
- Creare un nuovo ramo partendo da un ramo presente in origin 
        git fetch origin <remote-branch>
        git checkout -b <local-branch> origin/<remote-branch>

Esempio, da origin/development per i nuovi sviluppi 
        git fetch origin development
        git checkout -b dev/task_724 origin/development