using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DifyAI.ObjectModels
{
    public class ApplicationParametersResponse
    {
        /// <summary>
        /// 开场白
        /// </summary>
        [JsonPropertyName("opening_statement")]
        public string OpeningStatement { get; set; }

        /// <summary>
        /// 开场推荐问题列表
        /// </summary>
        [JsonPropertyName("suggested_questions")]
        public IReadOnlyList<string> SuggestedQuestions { get; set; }

        /// <summary>
        /// 启用回答后给出推荐问题。
        /// </summary>
        [JsonPropertyName("suggested_questions_after_answer")]
        public ParameterOptions SuggestedQuestionsAfterAnswer { get; set; }

        /// <summary>
        /// 语音转文本
        /// </summary>
        [JsonPropertyName("speech_to_text")]
        public ParameterOptions SpeechToText { get; set; }

        /// <summary>
        /// 文本转语音
        /// </summary>
        [JsonPropertyName("text_to_speech")]
        public TextToSpeechParameterOptions TextToSpeech { get; set; }

        /// <summary>
        /// 引用和归属
        /// </summary>
        [JsonPropertyName("retriever_resource")]
        public ParameterOptions RetrieverResource { get; set; }

        /// <summary>
        /// 标记回复
        /// </summary>
        [JsonPropertyName("annotation_reply")]
        public ParameterOptions AnnotationReply { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("more_like_this")]
        public ParameterOptions MoreLikeThis { get; set; }

        /// <summary>
        /// 用户输入表单配置
        /// </summary>
        [JsonPropertyName("user_input_form")]
        public IReadOnlyList<UserInputFormOptions> UserInputForm { get; set; }

        /// <summary>
        /// 内容审查
        /// </summary>
        [JsonPropertyName("sensitive_word_avoidance")]
        public SensitiveWordAvoidanceParameterOptions SensitiveWordAvoidance { get; set; }

        /// <summary>
        /// 文件上传配置
        /// </summary>
        [JsonPropertyName("file_upload")]
        public FileUploadOptions FileUpload { get; set; }

        /// <summary>
        /// 系统参数
        /// </summary>
        [JsonPropertyName("system_parameters")]
        public SystemParametersOptions SystemParameters { get; set; }
    }
}