#include <iostream>
#include <vector>
#include <ctime>
#include <chrono>

const int MAX = 900000;

struct AdjNode {
	int destination = -1;
	int weight = 0;
	AdjNode* next = nullptr;
};

int* dijkstra(AdjNode* list[], int vertices) {
	int used[32000] = { 0 };
	int* distance = new int[vertices];
	int iterations = 0;

	// ставим расстояние, равное оо
	for (int i = 0; i < vertices; ++i) {
		distance[i] = MAX;
		++iterations;
	}
	distance[0] = 0;

	for (int i = 0; i < vertices; ++i) {
		int v = -1;
		for (int j = 0; j < vertices; ++j) {
			if (!used[j] && (v == -1 || distance[j] < distance[v]))
				v = j;
			++iterations;
		}

		if (distance[v] == MAX) break;
		used[v] = true;

		for (AdjNode* e = list[v]->next; e != nullptr; e = e->next) {
			int len = e->weight;
			if (len) {
				int value = distance[v] + len;
				if (value < distance[e->destination])
					distance[e->destination] = value;
			}
			++iterations;
		}

	}
	std::cout << "Количество итераций: " << iterations << std::endl;
	return distance;
}



int* bellmanFord(AdjNode** adj, int vertices) {
	int* distance = new int[vertices];
	long iterations = 0;

	// инициализируем дистанции
	for (int i = 0; i < vertices; ++i) {
		distance[i] = MAX;
		++iterations;
	}

	// начинаем с корня
	distance[0] = 0;
	for (int i = 1; i < vertices; ++i)
		// релаксация
		for (int from = 0; from < vertices; ++from)
			for (AdjNode* to = adj[from]->next; to; to = to->next) {
				++iterations;
				if (distance[from] + to->weight < distance[to->destination])
					distance[to->destination] = distance[from] + to->weight;
			}
	std::cout << "Количество итераций: " << (-1)*iterations << std::endl;
	return distance;
}

int getUnattachedDestination(AdjNode* root, int vertices) {
	bool unique = false;
	int destination = -1;
	while (!unique) {
		AdjNode* node = root;
		destination = std::rand() % vertices;
		unique = true;
		for (; node; node = node->next)
			if (node->destination == destination) {
				unique = false;
				break;
			}
	}
	return destination;
}

void generate(AdjNode** adj, int vertices) {
	int minEdges = 10;
	const int maxWeight = 200;
	for (int i = 0; i < vertices; ++i) {
		AdjNode* node = adj[i];
		// идём в конец
		while (node->next)
			node = node->next;
		// добавляем в конец узлы
		for (int j = 0; j < minEdges; ++j) {
			int destination = getUnattachedDestination(adj[i], vertices);
			node->next = new AdjNode();
			node = node->next;
			node->weight = 1 + std::rand() % maxWeight;
			node->destination = destination;
			// создаем ребро для вершины
			AdjNode* back = adj[destination];
			while (back->next)
				back = back->next;
			back->next = new AdjNode();
			back = back->next;
			back->weight = node->weight;
			back->destination = i;
		}
	}
	int K = 6;
	for (int i = 0; i < K; ++i)
	{
		AdjNode* node = adj[i];
		while (node->next)
			node = node->next;
		for (int j = 0; j < K; ++j) {
			int destination = getUnattachedDestination(adj[i], vertices);
			node->next = new AdjNode();
			node = node->next;
			node->weight = 1 + std::rand() % maxWeight;
			node->destination = destination;
			AdjNode* back = adj[destination];
			while (back->next)
				back = back->next;
			back->next = new AdjNode();
			back = back->next;
			back->weight = node->weight;
			back->destination = i;
		}
	}
}

void printAdjList(AdjNode** adj, int vertices) {
	int limit = vertices > 20 ? 20 : vertices;
	for (int i = 0; i < limit; ++i) {
		std::cout << i << ": ";
		for (AdjNode* node = adj[i]->next; node != nullptr; node = node->next)
			std::cout << "(" << node->destination << ", " << node->weight << ") ";
		std::cout << std::endl;
	}
	std::cout << "..." << std::endl;
}

int main() {
	setlocale(0, "");
	int vertices = 12000;
	std::cout << "Список кратчайших путей:" << std::endl;
	AdjNode* adj[12000];
	// инициализируем путой список смежных вершин
	for (int i = 0; i < vertices; ++i) {
		adj[i] = new AdjNode;
		adj[i]->destination = i;
	}
	// Генерируем рёбра для списка
	generate(adj, vertices);
	printAdjList(adj, vertices);
	std::cout << "__________________________________________" << std::endl;
	std::cout << "Деикстра:" << std::endl;
	int* result = dijkstra(adj, vertices);
	std::cout << "Кратчайшие пути: ";
	int limit = vertices > 20 ? 20 : vertices;
	for (int i = 0; i < limit; ++i)
		std::cout << result[i] << " ";
	std::cout << std::endl << "Асимптотическая сложность: " << vertices*vertices + 20 * vertices << std::endl;
	std::cout << std::endl;
	std::cout << "__________________________________________" << std::endl;
	std::cout << "Беллман-Форд:" << std::endl;
	int* result2 = bellmanFord(adj, vertices);
	std::cout << "Кратчайшие пути: ";
	for (int i = 0; i < limit; ++i)
		std::cout << result2[i] << " ";
	std::cout << std::endl;
}