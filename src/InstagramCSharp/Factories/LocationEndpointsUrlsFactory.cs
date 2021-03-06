﻿using System.Web;

namespace InstagramCSharp.Factories
{
    public class LocationEndpointsUrlsFactory
    {
        public static string CreateLocationInfoUrl(long locationId, string accessToken)
        {
            var queryString = CreateLocationUrlQueryString(accessToken);
            return BuildLocationInfoUrl(locationId, InstagramAPIUrls.LocationsEndpointsUrl, queryString);
        }
        public static string CreateRecentLocationMediaUrl(long locationId, string accessToken, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            var queryString = CreateLocationUrlQueryString(accessToken, minId,maxId,minTimestamp,maxTimestamp);
            return BuildRecentLocationgedMediaUrl(locationId, InstagramAPIUrls.LocationsEndpointsUrl, queryString);
        }
        public static string CreateSearchLocationUrl(string accessToken, double distance = 1000, string facebookPlacesId = null, string foursquareId = null, double lat = 0, double lng = 0, string foursquareV2Id = null)
        {
            var queryString = CreateSearchLocationUrlQueryString(accessToken, distance, facebookPlacesId, foursquareId, lat, lng, foursquareV2Id);
            return BuildSearchLocationUrl(InstagramAPIUrls.LocationsEndpointsUrl, queryString);
        }
        private static string CreateLocationUrlQueryString(string accessToken, string minId = null, string maxId = null, long minTimestamp = 0, long maxTimestamp = 0)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            if (minId != null)
            {
                queryString["min_id"] = minId;
            }
            if (maxId != null)
            {
                queryString["max_id"] = maxId;
            }
            if (minTimestamp != 0)
            {
                queryString["min_timestamp"] = minTimestamp.ToString();
            }
            if (maxTimestamp != 0)
            {
                queryString["max_timestamp"] = maxTimestamp.ToString();
            }
            return queryString.ToString();
        }
        private static string CreateSearchLocationUrlQueryString(string accessToken, double distance, string facebookPlacesId, string foursquareId, double lat, double lng, string foursquareV2Id)
        {
            var queryString = HttpUtility.ParseQueryString("");
            queryString["access_token"] = accessToken;
            queryString["distance"] = distance.ToString();
            if (facebookPlacesId != null)
            {
                queryString["facebook_places_id"] = facebookPlacesId;
            }
            if (foursquareId != null)
            {
                queryString["foursquare_id"] = foursquareId;
            }
            if (lat != 0)
            {
                queryString["lat"] = lat.ToString();
            }
            if (lng != 0)
            {
                queryString["lng"] = lng.ToString();
            }
            if (foursquareV2Id != null)
            {
                queryString["foursquare_v2_id"] = foursquareV2Id;
            }
            return queryString.ToString();
        }
        private static string BuildLocationInfoUrl(long locationId, string url, string queryString)
        {
            url = string.Format(url + "/{0}", locationId);
            return url + "?" + queryString;
        }
        private static string BuildRecentLocationgedMediaUrl(long locationId, string url, string queryString)
        {
            url = string.Format(url + "/{0}/media/recent", locationId);
            return url + "?" + queryString;
        }
        private static string BuildSearchLocationUrl(string url, string queryString)
        {
            url = url + "/search";
            return url + "?" + queryString;
        }
    }
}
