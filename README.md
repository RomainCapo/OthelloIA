# OthelloIA
``Capocasale Romain et Moulin Vincent``
``INF3dlm-a``
``HE-ARC``

## Fonction de score
Pour la fonction de score, nous avons utilisé une matrice avec différents poids en fonctions de la position sur le plateau. La matrice utilisé est la suivante : 

{   6,   -3,    2,    2,    2,   -3,    6}
{  -3,   -4,    0,    0,    0,   -4,   -3}
{   3,    0,    1,    1,    1,    0,    3}
{   1,    0,    1,    1,    1,    0,    1}
{   3,    0,    1,    1,    1,    0,    3}
{   1,    0,    1,    1,    1,    0,    1}
{   3,    0,    1,    1,    1,    0,    3}
{  -3,   -4,    0,    0,    0,   -4,   -3}
{   6,   -3,    2,    2,    2,   -3,    6}

On peut constater que les poids les plus importants de la matrice se trouvent dans les coins. 
En effet, dans ce jeu il est très important d'avoir les coins du plateau pour maximiser les chances de gaganer.
Les bords de la matrice ont aussi des poids importants car il représente aussi un avantage dans le jeu. 
On peut également remarquer que les cases qui touches les 4 coins du plateau ont des scores négatifs. 
Car en effet, si on à un pion dans cette partie du plateau, il risque de se faire manger et l'adversaire se retrouvera alors dans un coin.
On remarque aussi que d'avoir un pion au centre du plateau présente aussi un petit avantage stratégique sur l'adversaire.
Pour créér la matrice des scores nous nous sommes inspirés des matrices présentent sur le web et nous les avons adaptés à notre grille de taille 9x7.

Notre fonction de score va alors se contenter de parcourir le plateau de jeu case par case. 
Si la case est vide on ne fait rien. Si la case est occupé par l'ordinateur on va alors additioner le poids de la matrice par rapport à la position dans le plateau de jeu.
Si la case appartient à l'adversaire on va soustraire le score de la matrice.

Pour finir, on teste encore si le plateau de jeu corresponds à une fin de partie. 
C'est a dire qu'un des deux joueurs aurait gagné.
Si l'ordinateur à gagner, on retourne un très grand nombre pour indiquer que cette configuration de jeu est execellent car nous sommes gagant.
Si l'adversaire à gagner, on retourne un très petit nombre. 
Si le plateau de jeu n'est pas dans une configuration de fin de partie on retourne le score calculé par la matrice de poids.