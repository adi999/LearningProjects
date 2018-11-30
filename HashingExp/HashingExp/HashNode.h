#pragma once

template <typename K, typename V>

class HashNode
{
public:
	V Value;
	K Key;

	HashNode(K key, V value)
	{
		this->Value = value;
		this->Key = key;
	}
};

