#pragma once
template<typename K, typename V>

class HashMap
{
	HashNode <K, V> **arr;
	int capacity;
	int size;

public:
	HashMap();
	~HashMap();
};

