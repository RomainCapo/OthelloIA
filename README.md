# OthelloIA

Projet réalisé durant le 5ème semestre de Bachelor dans le cours d'inteligence artificielle.

## Team

* Romain Capocasale [@RomainCapo](https://github.com/RomainCapo)
* Vincent Moulin [@dicksor](https://github.com/dicksor)

## Fonction de score
La fonction de score est composé de 5 étapes :
	* Matrice des scores
	* Calcul d'un poids en fonction du dernier coup du joueur
	* Calcul d'un poids en fonction de la partiré des pions
	* Calcul d'un poids en fonction du nombre de coin capturé
	* Calcul d'une situation de fin de partie


### Matrice des scores
La matrice de score contient différents poids en fonctions de la position sur le plateau. La matrice utilisé est la suivante :

{ 500,  -25,   25,    3,   25,  -25,  500}
{ -25, -150,    0,    0,    0, -150,  -25}
{  25,    0,    3,    3,    3,    0,   25}
{   3,    0,    3,    3,    3,    0,    3}
{  25,    0,    3,    3,    3,    0,   25}
{   3,    0,    3,    3,    3,    0,    3}
{  25,    0,    3,    3,    3,    0,   25}
{ -25, -150,    0,    0,    0, -150,  -25}
{ 500,  -25,   25,    3,   25,  -25,  500}

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

### Calcul d'un poids en fonction du dernier coup du joueur
Dans le jeu, il peut être intessant de jouer le dernier coup car, il permet de manger beaucoup de pion au dernier tour.
Pour calculer si l'ordinateur jouera le dernier coup il suffit de compter le nombre total de pion sur le plateau + 1 (pour simuler le prochain tour). On divise ensuite ce nombre par 2, si ce nombre est pair l'ordinateur ne jouera pas le dernier coup. Si c'est impaire il jouera le dernier coup.
Nous avons alors ajouté un poids de 25 au score total si l'ordinateur joue le dernier coup sinon 0.

### Calcul d'un poids en fonction de la partiré des pions
La fonction de score va également calculer la différence de pièce entre l'ordinateur et l'adversaire.
Cette différence est calculé en divisant (le nombre de pion de l'ordi - le nombre de pion de l'adversaire) par (le nombre de pion de l'ordi + le nombre de pion de l'adversaire).
Cette différence sera multiplié à un poids de 25, puis ajouté au score total.

### Calcul d'un poids en fonction du nombre de coin capturé
La fonction de score calcule un score en fonction du nombre coin detenu par l'ordinateur et par l'adversaire.
Ce score est calculé en divisant (le nombre de coin detenu par l'ordi - le nombre de coin detenu par l'adversaire) par (le nombre de coin detenu par l'ordi + le nombre de coin detenu par l'adversaire).
Ce score est multiplié par un poids de 100 et ajouté au score total.

### Calcul d'une situation de fin de partie
Pour finir, on teste encore si le plateau de jeu corresponds à une fin de partie.
C'est a dire qu'un des deux joueurs aurait gagné.
Si l'ordinateur à gagner, on retourne un très grand nombre pour indiquer que cette configuration de jeu est execellent car nous sommes gagant.
Si l'adversaire à gagner, on retourne un très petit nombre.
Si le plateau de jeu n'est pas dans une configuration de fin de partie on retourne le score calculé à l'aide des étapes préceddentes.

Pour la fonction nous nous sommes en partie inspiré du site suivant : https://kartikkukreja.wordpress.com/2013/03/30/heuristic-function-for-reversiothello/
