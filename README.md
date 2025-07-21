# ROBOT FACTORY

### Authors:
- Loriane HILDERAL
- Clarence HIRSCH
- Alan DIOT

### Branches:
- naive : naive implementation without design patters
- step-2 : step 2 implementation with design patterns and more logic
- step-3 : step 3 implementation with complementary modules and more logic

### C# implementations of Design Patterns

Une usine de robots souhaite automatiser et simplifier le suivi de sa production.
Les différentes pièces nécessaires à l’assemblage d’un robot sont produites dans d’autres
usines et leur production ne fait pas partie de vos préoccupations, vous devrez uniquement
vous charger du système d’assemblage final.
Vous devrez cependant prendre en considération le stock de pièces disponible dans l’usine.

Chaque robot classique est constitué de :
- 1 module principal
- 1 générateur
- 1 module de préhension
- 1 module de déplacement

Afin de mener à bien l’assemblage d’un robot, il faudra découper le processus d’assemblage en
plusieurs instructions.
On souhaite donc écrire un programme qui prend en entrée une commande de production et
renvoie la liste des instructions à exécuter pour assembler les robots demandés.



### 3.1 Edition de l’inventaire des pièces disponibles
Vous devez pouvoir produire une sortie console indiquant l’intégralité du stock de l’usine.
Cet inventaire devra inclure les différents robots produits ainsi que l’ensemble des pièces sous
le format suivant :

A Robot1
[...]
B RobotN
C Piece1
[...]
D PieceM

Où A, B, C et D représentent respectivement les quantités disponibles de Robot1, RobotN,
Piece1 et PieceN.

Afin de produire cette sortie, l’utilisateur devra entrer l’instruction suivante :
STOCKS


### 3.2 Prise en compte des commandes
Pour le reste des instructions de l’utilisateur, votre programme devra récupérer des commandes
sous la forme d'entrée textuelle en console.
On appelle commande, un listing quantifié de robots.

Les instructions sont de la forme :

`[USER_INSTRUCTION] A Robot1`
Où A est la quantité de Robot1.

`[USER_INSTRUCTION] A Robot1, B Robot2, C Robot3`
Où A, B et C sont respectivement les quantités de Robot1, Robot2 ou Robot3 à produire.
Une commande peut contenir plusieurs occurrences du même robot, ainsi une instruction de la
forme :
`[USER_INSTRUCTION] A Robot1, B Robot2, C Robot1`
devra être considérée comme :
`[USER_INSTRUCTION] A+C Robot1, B Robot2`

La liste des arguments des instructions sera abrégée en ARGS dans la suite du sujet.


### 3.3 Edition de l’inventaire des pièces nécessaires
L’utilisateur peut demander l’inventaire des pièces nécessaires à la production d’une
commande.
Pour cela, il peut utiliser l’instruction :
NEEDED_STOCKS ARGS
Après avoir interprété la commande en entrée, vous devez pouvoir produire une sortie console
respectant le format suivant :
A Robot1 :
Quantité1 Piece1
[...]
QuantitéN PieceN
B Robot2 :
Quantité1 Piece1
[...]
QuantitéN PieceN
Total :
SommeDesQuantités1 Piece1
[...]
SommeDesQuantitésN PieceN


### 3.4 Édition des instructions d’assemblage
L’utilisateur peut demander la liste d’instructions à exécuter pour l’assemblage d’une
commande donnée.
Pour cela il peut utiliser l’instruction suivante :
`INSTRUCTIONS ARGS`

Après avoir interprété la commande en entrée, vous devez pouvoir produire une sortie console
contenant l’intégralité des instructions à effectuer respectant le format suivant :

PRODUCING Robot1

INSTRUCTION1_1 ARGS1_1

[...]

INSTRUCTION1_N ARGS1_N

FINISHED Robot1

PRODUCING Robot2

INSTRUCTION2_1 ARGS2_1

[...]

INSTRUCTION2_M ARGS2_N

FINISHED Robot2

Où INSTRUCTIONX_Y représente la Yeme instruction à exécuter pour la production du robot X
et ARGSX_Y la liste d’arguments de l’instruction associée.

Dans le cas où vous devez produire plusieurs fois le même modèle de robot, votre sortie devra
contenir plusieurs fois les instructions concernées.
Certaines pièces nécessitent l’installation de programmes afin de fonctionner, il faudra donc
bien penser à inclure également ces étapes-là.
Si une pièce possède ce type de contrainte, cela sera mentionné directement dans la liste des
pièces disponibles plus loin dans ce sujet.

Plusieurs instructions sont actuellement disponibles pour effectuer l’assemblage d’un robot :
- Indiquer le début de la production du robot Robot1 :
`PRODUCING Robot1`
- Indiquer la fin de la production du robot Robot1 :
`FINISHED Robot1`
- Sortir du stock A exemplaires de la pièce Piece1 :
`GET_OUT_STOCK A Piece1`
- Assembler les pièces Piece1 et Piece2 afin de produire Assembly1 :
`ASSEMBLE Assembly1 Piece1 Piece2`
- Installer le System1 sur la Piece1 :
`INSTALL System1 Piece1`

Il est nécessaire d’avoir sorti les pièces du stock avant de pouvoir les assembler.

Il est possible d’utiliser cette instruction sans nommer le résultat, mais cela peut complexifier la
suite des instructions. Un exemple est disponible en fin de sujet mettant en avant cela.

Il peut donc exister plusieurs suites d’instructions valides pour un même robot !
Ce jeu d’instruction peut être amené à évoluer dans la suite du projet.
Ces instructions ne sont actuellement pas disponibles pour l’utilisateur et n’existent que l’édition
des instructions.


### 3.5 Vérification d’une commande
L’utilisateur peut demander la vérification d’une commande donnée.
Pour cela il peut utiliser l’instruction suivante :
`VERIFY ARGS`

Si la commande est incorrecte, le résultat sera affiché sous la forme :
`ERROR Message`
Où Message indique pourquoi la commande est incorrecte

Si la commande est valide et que le stock est suffisant, le résultat sera :
`AVAILABLE`

Si la commande est valide mais que le stock n’est pas suffisant, le résultat sera :
`UNAVAILABLE`


### 3.6 Exécution d’une commande
L’utilisateur peut demander la production d’une commande donnée.
Pour cela il peut utiliser l’instruction suivante :
`PRODUCE ARGS`

Si la commande est incorrecte ou ne peut pas être produite, le résultat sera affiché sous la
forme :
`ERROR Message`
Où Message indique pourquoi la commande est incorrecte

Si la commande peut être exécutée sans souci, les stocks doivent être mis à jour et le résultat
sera affiché sous la forme :
`STOCK_UPDATED`
Où Message indique pourquoi la commande est incorrecte


### Design patterns à l'étape 2 puis 3 : 

Nous avons rajouté les design patterns suivants : 
- Singletons pour la gestion du stock et le catalogue de templates de robots et de commande
- Builder pour la création d'un robot
- Strategy pour les contraintes de création de robot
- Command pour les différentes entrées utilisateur
