/******************************************************************************/

#pragma once

/******************************************************************************/

namespace CM {

/* retard stl's cripled template min/max() sux */
#define _max( a, b ) ( ((a)>(b))? (a): (b) )
#define _min( a, b ) ( ((a)<(b))? (a): (b) )
/* math.h's abs() sux in ancient libc */
#define _abs( a ) ( (a)>0? (a): -(a) )
/* we need M_PI from math.h */
#define _USE_MATH_DEFINES
/* sign of number */
#define sgn(x) ((x)>0?+1:(x)<0?-1:0)

#define cut_val(v,min_v,max_v) std::max(std::min(v,max_v),min_v)
template<typename T> inline T clamp_min_max(T val, T min_, T max_) {return _max(_min(val, max_), min_);}
template<typename T> inline T clamp0_1(T val) {return clamp_min_max(val, (T)0, (T)1);}

/******************************************************************************/

/* renames */
//#ifdef VC
//	#define snprintf _snprintf
//	#define atoll _atoi64
//	#define strtoll _strtoi64
//	#define ftime _ftime
//	#define timeb _timeb
//	#define strcasecmp _stricmp
//#endif

/******************************************************************************/

/* defines */


/******************************************************************************/


/******************************************************************************/

/* foreach */
#define foreach_generic(iter_sub,Iter,type,Con) \
	for ( type::iter_sub Iter = (Con).begin() ; Iter != (Con).end() ; ++Iter )
#define foreach_generic_rev(iter_sub,Iter,type,Con) \
	for ( type::iter_sub Iter = (Con).rbegin() ; Iter != (Con).rend() ; ++Iter )
#ifdef foreach
	#undef foreach
#endif
#define foreach(          Iter,type,Con) foreach_generic    (iterator              ,Iter,type,Con)
#define foreach_rev(      Iter,type,Con) foreach_generic_rev(reverse_iterator      ,Iter,type,Con)
#define foreach_const(    Iter,type,Con) foreach_generic    (const_iterator        ,Iter,type,Con)
#define foreach_const_rev(Iter,type,Con) foreach_generic_rev(const_reverse_iterator,Iter,type,Con)

#define foreach_map_generic(iter_sub,Iter,type_part1,type_part2,Con) \
	for ( type_part1,type_part2::iter_sub Iter = (Con).begin() ; Iter != (Con).end() ; ++Iter )

#define foreach_map_generic_rev(iter_sub,Iter,type_part1,type_part2,Con) \
	for ( type_part1,type_part2::iter_sub Iter = (Con).rbegin() ; Iter != (Con).rend() ; ++Iter )

#define foreach_map(      Iter, key, value, Con) foreach_map_generic(      iterator,Iter,key,value,Con)
#define foreach_map_const(Iter, key, value, Con) foreach_map_generic(const_iterator,Iter,key,value,Con)
#define foreach_map_rev(  Iter, key, value, Con) foreach_map_generic_rev(reverse_iterator,Iter,key,value,Con)
#define foreach_map_const_rev(Iter, key, value, Con) foreach_map_generic_rev(const_reverse_iterator,Iter,key,value,Con)

#define foreach_array( Iter, type, Array ) \
	for ( const char* const* Iter = Array ; *Iter != NULL ; ++Iter )

/******************************************************************************/

/* replace for stupid stl's find() in maps/sets/etc */
template <typename container, typename object>
bool Find(const container& Container, const object& Object)
{
	return Container.find(Object) != Container.end();
}

#define MapGet(Map, Val) Map.find(Val)->second 
#define MapPtGet(Map, Val) Map->find(Val)->second 
#define ContGet(Cont, Val) (*Cont.find(Val))
#define ContPtGet(Cont, Val) (*Cont->find(Val)) 
#define IsFindIf(cont,rule) (find_if((cont).begin(), (cont).end(), rule) != (cont).end())
#define GetFindIf(cont,rule) (find_if((cont).begin(), (cont).end(), rule))

/* convert vector to map by id */
#define ContainerToMap( con_type, Con, Map, Index ) {\
	Check ( Map.size() == 0 ) ;\
	foreach_const ( It, con_type, Con )\
	{	CheckError ( !Find(Map,It->Index), "duplicated index" ) ; Map[It->Index] = *It ; } }

#define UpdateMapFromContatiner( con_type, Con, Map, Index ) {\
	foreach_const ( It, con_type, Con )\
{	Map[It->Index] = *It ; } }


/* erase map's element by iterator, point to next */
template <typename T> void MapErase ( T& Container, typename T::iterator& It )
{
	typename T::iterator Next = (++It)--;
	Container.erase(It);
	It = Next;
}

/* find value in container */
template <typename container, typename element> bool ContainerFind ( const container& Container, const element& Value )
{
	foreach_const ( It, typename container, Container )
	{	if ( *It == Value ) { return TRUE ; } }
	return FALSE ;
}

/* convert from map to vector */
template <typename tmap, typename tvec> void MapToVector (const tmap& map, tvec& vec )
{
	typename tmap::const_iterator i = map.begin();
	while (i != map.end())
	{
		vec.push_back(i->second);
		i++;
	}
}

template<typename T>
int GetMinElementIndex(const T& vec)
{
	if (vec.empty()) return -1;
	int minIdx = 0;
	typename T::value_type minW = vec.at(minIdx);
	for (int i = 0; i < (int)vec.size(); i++)
	if (vec.at(i) < minW)
	{
		minW = vec.at(i);
		minIdx = i;
	}

	return minIdx;
};

template<typename T>
int GetMaxElementIndex(const T& vec)
{
	if (vec.empty()) return -1;
	int maxIdx = 0;
	typename T::value_type maxW = vec.at(maxIdx);
	for (int i = 0; i < (int)vec.size(); i++)
	if (vec.at(i) > maxW)
	{
		maxW = vec.at(i);
		maxIdx = i;
	}

	return maxIdx;
};

#if 0
#define maptovector(MapType_1, MapType_2, Map, Vec ) {\
	Check ( Vec.empty() ) ; \
 	foreach_map_const ( It,MapType_1,MapType_2,Map ) \
	{ Vec.push_back(It->second); }}
#endif

}

