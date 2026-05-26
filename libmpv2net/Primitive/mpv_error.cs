using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libmpv2net
{
    /// <summary>
    /// List of error codes that may be returned by mpv calls. 0 or positive,
    /// is a success code.
    /// </summary>
    public enum mpv_error
    {
        /// <summary>
        /// Operation successful; error code operations may also return 
        /// positive. 
        /// </summary>
        Success = 0,
        /// <summary>
        /// Event ringbuffer has been choked; no (new) async requests can
        /// be made for the currently pending ones have yet to be answered.
        /// Should only really happen in case of mpv freezing while requests
        /// are still being done.
        /// </summary>
        EventQueueFull = -1,
        /// <summary>
        /// Memory allocation failed.
        /// </summary>
        NoMemory = -2,
        /// <summary>
        /// MPV Core wasn't initialized
        /// </summary>
        Uninitialized = -3,
        /// <summary>
        /// For parameter-related errors that can't get a more specific error 
        /// code.
        /// </summary>
        InvalidParameter = -4,
        /// <summary>
        /// When a request to set an option that doesn't exist, was made.
        /// </summary>
        OptionNotFound = -5,
        /// <summary>
        /// When the option was present, but the supplied format did not 
        /// exist, or is not supported for this particular option.
        /// </summary>
        OptionFormat = -6,
        /// <summary>
        /// When the option was present, the format was applicable, but the
        /// option still couldn't be set. Typically a parsing error.
        /// </summary>
        OptionError = -7,
        /// <summary>
        /// Requested property name did not exist.
        /// </summary>
        PropertyNotFound = -8,
        /// <summary>
        /// Requested property name did exist, but the supplied format did
        /// not exist, or was not supported.
        /// </summary>
        PropertyFormat = -9,
        /// <summary>
        /// Property and format existed, but wasn't available for use (yet)
        /// for example, when accessing audio settings while the audio
        /// subsystem is out.
        /// </summary>
        PropertyUnavailable = -10,
        /// <summary>
        /// Generic property get/set error that couldn't be more specific.
        /// </summary>
        PropertyError = -11,
        /// <summary>
        /// Generic command error that couldn't be more specific.
        /// </summary>
        CommandError = -12,
        /// <summary>
        /// File loading conked out; check mpv_event_end_file.error
        /// </summary>
        LoadingFailed = -13,
        /// <summary>
        /// Initialization of the audio output subsystem failed.
        /// </summary>
        AudioOutputFailed = -14,
        /// <summary>
        /// Initialization of the video output subsystem failed.
        /// </summary>
        VideoOutputFailed = -15,
        /// <summary>
        /// When there is nothing (left) to continue playing, may also
        /// happen when a valid container doesn't have usable A/V streams.
        /// </summary>
        NothingToPlay = -16,
        /// <summary>
        /// File wasn't a sensible container, or is very broken.
        /// </summary>
        UnknownFormat = -17,
        /// <summary>
        /// Typically implies system requirements do not permit use 
        /// of feature.
        /// </summary>
        Unsupported = -18,
        /// <summary>
        /// Function was invoked, but not implemented.
        /// </summary>
        NotImplemented = -19,
        /// <summary>
        /// When no other error code suffices.
        /// </summary>
        Generic = -20,        
    }
}
