using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace libmpv2net.Functions
{
    public static class mpv_commands
    {
        /// <summary>
        /// Send a command and its args as per documentation
        /// </summary>
        /// <param name="ctx">Client context</param>
        /// <param name="args">String args (command first)</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_command_result mpv_command(
            mpv_handle ctx, [MarshalAs(UnmanagedType.LPArray)] mpv_string[] args);

        /// <summary>
        /// Like mpv_command, but strongly and strictly typed using 
        /// mpv_node. It expects either an mpv_format NodeList, with
        /// the command name at position 0, or an mpv_format NodeMap, with
        /// the command name at key _name, and the args named as per 
        /// documentation.
        /// </summary>
        /// <param name="ctx">Client context</param>
        /// <param name="args">
        /// Args as mpv_node that is NodeList or NodeMap</param>
        /// <param name="result">
        /// Is expected to output into a pointer to an mpv_node_unknown,
        /// but may be left to null if we're not expecting or desiring
        /// a reply. Use mpv_free_node_contents.</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_command_node_result mpv_command_node(
            mpv_handle ctx, mpv_node_pointer args, mpv_node_pointer result);

        /// <summary>
        /// Works like mpv_command, but useful if we're expecting a response
        /// as well.
        /// </summary>
        /// <param name="ctx">Client context</param>
        /// <param name="args">Args as string array</param>
        /// <param name="result">Use mpv_free_node_contents.</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_command_ret_result mpv_command_ret(
            mpv_handle ctx, [MarshalAs(UnmanagedType.LPArray)] mpv_string[] args,
            mpv_node_pointer result);

        /// <summary>
        /// Works like mpv_command but takes a plain string, 
        /// it splits and parses it itself, which may be flakey
        /// sometimes.
        /// </summary>
        /// <param name="ctx">Client context</param>
        /// <param name="args">Single string with command and args</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_command_string_result mpv_command_string(
            mpv_handle ctx, [MarshalAs(UnmanagedType.LPStr)] string args);

        /// <summary>
        /// Works like mpv_command, but doesn't block, instead posting
        /// its success or failure back as an event.
        /// </summary>
        /// <param name="ctx">Client context</param>
        /// <param name="reply_userdata">Our tracking number which may
        /// also be used for cancellation</param>
        /// <param name="args">String array of arguments</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_command_async_result mpv_command_async(
            mpv_handle ctx, long reply_userdata,
            [MarshalAs(UnmanagedType.LPArray)] mpv_string[] args);

        /// <summary>
        /// Works like mpv_command_async, but instead of a string array,
        /// we can stick in a node_map or node_list like mpv_command_node
        /// </summary>
        /// <param name="ctx">Client context</param>
        /// <param name="reply_userdata">Use this as our tracking number</param>
        /// <param name="args">Allocate a node here, and free its 
        /// contents using mpv_free_node_contents after use. Leave
        /// null if output is not desired.</param>
        /// <returns></returns>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern mpv_result mpv_command_node_async(
            mpv_handle ctx, long reply_userdata,
            mpv_node_pointer args);

        /// <summary>
        /// Use this to cancel async commands that had their reply_userdata
        /// set.
        /// </summary>
        /// <param name="ctx">Client context</param>
        /// <param name="reply_userdata">The tracking number we used
        /// earlier.</param>
        [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void mpv_abort_async_command(
            mpv_handle ctx, long reply_userdata);
    }
}
